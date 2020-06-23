using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nibo.App.ViewModel;
using Nibo.Business.Interfaces;
using Nibo.Business.Models;

namespace Nibo.App.Controllers
{
    public class BankStatementsController : Controller
    {
        private readonly IBankStatementRepository _bankStatementRepository;
        private readonly IMapper _mapper;
        private readonly IIOService _ioservice;
        public readonly IBankStatementService _bankStatementService;

        public BankStatementsController(IBankStatementRepository bankStatementRepository, IMapper mapper, IIOService ioservice, IBankStatementService bankStatementService)
        {
            _bankStatementRepository = bankStatementRepository;
            _mapper = mapper;
            _ioservice = ioservice;
            _bankStatementService = bankStatementService;
        }


        // GET: BankStatements
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<BankStatementViewModel>>(await _bankStatementRepository.GetBankStatementTransactions()));


        }

        // GET: BankStatements/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(BankStatementViewModel BankStatementViewModel)
        {
            if (!ModelState.IsValid) return View(BankStatementViewModel);

            if (!await Import(BankStatementViewModel.FileUpload))
            {
                ViewData["Erro"] = "A file with the same name already exists!";
                return View("create");
            }

            var filename = BankStatementViewModel.FileUpload.FileName;

            var builder = _ioservice.ReadFile(filename);

            // transform
            var bank = new BankStatement();
            var ofx = bank.Create(builder, bank.Id);

            await _bankStatementService.Save(ofx);

            ViewData["Message"] = "Send to Database";


            return View("create");
        }


        [HttpPost]
        public IActionResult RemoveRecords()
        {

            _bankStatementService.RemoveRecords();
            ViewData["remove"] = "Remove Records";

            return View("Create");
        }



        [HttpPost]
        public async Task<IActionResult> RemoveDuplicates(BankStatementViewModel BankStatementViewModel)
        {
            var list = await _bankStatementRepository.GetBankStatementTransactions();
            var listTransactions = new List<Transaction>();
            foreach (var item in list)
            {
                listTransactions.AddRange(item.Transactions);
            }

            await _bankStatementService.RemoveDuplicates(listTransactions);
            ViewData["removeDuplicates"] = "Remove Duplicates";
            return View("Create");
        }

        private async Task<bool> Import(IFormFile arquivo)
        {
            if (arquivo.Length <= 0) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Data", arquivo.FileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Já existe um arquivo com este nome!");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            return true;
        }
    }
}
