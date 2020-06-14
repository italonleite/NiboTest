using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
            return View(_mapper.Map<IEnumerable<BankStatementViewModel>>(await _bankStatementRepository.ObterTodos()));
           
        }

       
        // GET: BankStatements/Create
        public IActionResult Create()
        {
            return View();
        }

    }
}
