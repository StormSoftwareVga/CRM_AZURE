﻿using Microsoft.AspNetCore.Mvc;
using System;
using CRM.Application;

namespace CRM.Controllers
{
    //[Route("api/[controller]"), ApiController]
    //public class VariacaoController : ControllerBase
    //{
    //    private readonly IVariacaoService variacaoService;

    //    public VariacaoController(IVariacaoService variacaoService)
    //    {
    //        this.variacaoService = variacaoService;
    //    }

    //    [HttpGet]
    //    public IActionResult Get()
    //    {
    //        return Ok(this.variacaoService.Get());
    //    }

    //    [HttpGet("{dia}")]
    //    public IActionResult GetById(int dia)
    //    {
    //        return Ok(this.variacaoService.GetById(dia));
    //    }

    //    [HttpPost]
    //    public IActionResult Post(VariacaoRequestViewModel variacaoRequestViewModel)
    //    {
    //        return Ok(this.variacaoService.Post(variacaoRequestViewModel));
    //    }

    //    [HttpPut]
    //    public IActionResult Put(VariacaoViewModel variacaoViewModel)
    //    {
    //        return Ok(this.variacaoService.Put(variacaoViewModel));
    //    }

    //    [HttpDelete("{id}")]
    //    public IActionResult Delete(string id)
    //    {
    //        return Ok(this.variacaoService.Delete(id));
    //    }

    //    [HttpDelete()]
    //    public IActionResult Delete()
    //    {
    //        return Ok(this.variacaoService.Delete());
    //    }
    //}
}
