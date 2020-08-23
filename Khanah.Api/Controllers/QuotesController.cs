using System.Collections.Generic;
using System.Linq;
using Khanah.Api.Data;
using Khanah.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace Khanah.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class QuotesController : ControllerBase
    {
        private readonly QuotesDBContext _quotesDB;

        public QuotesController(QuotesDBContext quotesDB)
        {
            _quotesDB = quotesDB;
        }
        [HttpGet]
        public IActionResult GetQuotes(string sort)
        {
            try
            {
                IQueryable<Quote> quotes;
                switch (sort)
                {
                    case "asc":
                        quotes = _quotesDB.Quotes.OrderBy(x=>x.Body);
                        break;
                    case "desc":
                        quotes =_quotesDB.Quotes.OrderByDescending(x=>x.Body);
                        break;
                    default:
                        quotes = _quotesDB.Quotes;
                        break;
                }                
                 return Ok(quotes);
            }
            catch(Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,exception.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetQuoteById(int id)
        {
            try
            {
                var quote = _quotesDB.Quotes.Find(id);
                return StatusCode(StatusCodes.Status200OK, quote);
            }
            catch(Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,exception.Message);
            }
        }
        [HttpPost]
        public IActionResult PostQuote([FromBody]Quote quote)
        {
            try
            {
                _quotesDB.Quotes.Add(quote);
                _quotesDB.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, "quote created successfully");
            }
            catch(Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,exception.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult PutQuote(int id,[FromBody]Quote quote)
        {
            try
            {
                var quoteToBeEdit = _quotesDB.Quotes.Find(id);
                quoteToBeEdit.Author = quote.Author;
                quoteToBeEdit.Body = quote.Body;
                quoteToBeEdit.Genre = quote.Genre;
                _quotesDB.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, "quote edited successfully");
            }
            catch(Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,exception.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteQuote(int id)
        {
            try
            {
                var quote = _quotesDB.Quotes.Find(id);
                _quotesDB.Quotes.Remove(quote);
                _quotesDB.SaveChanges();
                return StatusCode(StatusCodes.Status200OK , "quote deleted successfully");
            }
            catch(Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,exception.Message);
            }
        }
    }
}