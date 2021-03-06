﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Article.Application.Data;
using Article.Application.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Article.Application.Controllers
{
    [Route("api/[controller]")]
    public class ArticlesController : Controller
    {
        private readonly IRepository _repository;

        public ArticlesController(IRepository repository)
        {
            _repository = repository;
        }


        public ActionResult GetArticles()
        {
            var articles = _repository.Articles().ToList();

            if (articles.Count() > 0) {
                return Ok(articles);
            }
            else {
                return new BadRequestResult();
            }
        }

        [HttpPost("{id}")]
        public ActionResult GetArticleById(int id)
        {
            var article = _repository.Article(id);

            if (article != null) {
                return Ok(article);
            }
            else {
                return BadRequest(article);
            }
        }

        [HttpPost]
        [Route("add")]
        public ActionResult AddArticle([FromBody]ArticleModel entity)
        {
            try
            {
                _repository.Add(entity);
                _repository.SaveAll();

                return Ok(entity);
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
           
        }
        [HttpPost]
        [Route("delete")]
        public ActionResult DeleteArticle([FromBody]ArticleModel entity)
        {
            try
            {
                _repository.Delete(entity);
                _repository.SaveAll();
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

        }
    }
}
