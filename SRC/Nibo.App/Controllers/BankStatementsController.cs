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

namespace Nibo.App.Controllers
{
    public class BankStatementsController : Controller
    {
        private readonly IBankStatementRepository _bankStatementRepository;
        private readonly IMapper _mapper;

        public BankStatementsController(IBankStatementRepository bankStatementRepository, IMapper mapper)
        {
            _bankStatementRepository = bankStatementRepository;
            _mapper = mapper;
        }


        // GET: BankStatements
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<BankStatementViewModel>>(await _bankStatementRepository.ObterBankStatementTransaction()));
           
        }

       
        // GET: BankStatements/Create
        public IActionResult Create()
        {
            return View();
        }

        private async Task<bool> UploadArquivo(IFormFile arquivo)
        {
            if (arquivo.Length <= 0) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", arquivo.FileName);

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
