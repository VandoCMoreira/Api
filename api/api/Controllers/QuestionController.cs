//-----------------------------------------------------------------------
// <copyright file="QuestionController.cs" company="Bliss Application">
// Copyright (c) Vando Moreira. All rights reserved.
// </copyright>
// <author>Vando.Moreira<author>
// WebApi - Bliss Application
//-----------------------------------------------------------------------
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using api.Models;
using System.Collections.Generic;
using System;
using System.Web.Http.Cors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace api.Controllers
{

    [TestClass]
    // Allow CORS for all origins. (Caution!)
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class QuestionController : ApiController
    {
        Model entityDbModel = new Model();

        [TestMethod]
        // GET: api/question
        public IQueryable<Question> Getquestion()
        {
            try
            {
                return entityDbModel.Question;
            }
            catch (Exception)
            {

                throw;
            }

        }

        [TestMethod]
        // GET: api/question/5
        [ResponseType(typeof(Question))]
        public IHttpActionResult Getquestion(int id)
        {
            try
            {
                Question question = entityDbModel.Question.Find(id);
                if (question == null)
                {
                    return NotFound();
                }

                return Ok(question);

            }
            catch (Exception)
            {

                throw;
            }

        }

        [TestMethod]
        // PUT: api/question/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putquestion(int id, Question question)
        {
            using (DbContextTransaction transaction = entityDbModel.Database.BeginTransaction())
            {
                try
                {
                    //retorna os choices
                    var choice = entityDbModel.Choice.Where(_ => _.QuestionId == question.QuestionId).ToList();

                    entityDbModel.Choice.RemoveRange(choice);
                    entityDbModel.SaveChanges();

                    //recria a listagem
                    Question Question = new Question();

                    Question.QuestionId = question.QuestionId;
                    Question.QuestionName = question.QuestionName;
                    Question.ImageUrl = question.ImageUrl;
                    Question.ThumbUrl = question.ThumbUrl;

                    entityDbModel.Entry(Question).State = EntityState.Modified;
                    entityDbModel.SaveChanges();

                    var Localchoices = new List<Choice>();

                    //percorre o parametro de entrada
                    if (question.Choices != null && question.Choices.Count > 0)
                    {
                        foreach (var item in question.Choices)
                        {
                            Localchoices.Add(new Choice
                            {
                                QuestionId = question.QuestionId,
                                ChoiceName = item.ChoiceName,
                                Votes = item.Votes
                            }

                            );
                        }
                    }

                    entityDbModel.Choice.AddRange(Localchoices);
                    entityDbModel.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {

                    transaction.Rollback();

                    if (!questionExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [TestMethod]
        // POST: api/question
        [ResponseType(typeof(QuestionDTO))]
        public IHttpActionResult Postquestion(QuestionDTO QuestionDTO)
        {
            try
            {
                if (QuestionDTO == null)
                {
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                //Converter para o objeto Question e salvar no banco
                Question Question = new Question();
                Question.QuestionId = QuestionDTO.QuestionDTOId;
                Question.QuestionName = QuestionDTO.QuestioDTOName;
                Question.ImageUrl = QuestionDTO.ImageUrl;
                Question.ThumbUrl = QuestionDTO.ThumbUrl;
                Question.PublishedAt = QuestionDTO.PublishedAt;

                Question.Choices = new List<Choice>();

                if (QuestionDTO.Choices != null && QuestionDTO.Choices.Length > 0)
                {
                    foreach (var item in QuestionDTO.Choices)
                    {
                        Question.Choices.Add(new Choice
                        {
                            ChoiceName = item
                        });
                    }

                }

                entityDbModel.Question.Add(Question);
                entityDbModel.SaveChanges();

                return CreatedAtRoute("DefaultApi", new { id = Question }, Question);

            }

            catch (Exception)
            {

                throw;
            }

        }

        [TestMethod]
        // GET: api/Question
        public IQueryable<Question> GetFilterQuestion(int limit, int offset, string filter)
        {
            try
            {
                string sql;
                List<Question> resultQuestion = new List<Question>();

                if (!string.IsNullOrEmpty(filter))
                {
                    sql = "Select distinct q.* from Questions q inner " +
                                                        "join Choices c on (q.QuestionId = c.QuestionId) " +
                                                        "where upper(q.QuestionName) in ('" + filter.ToUpper() + "') or upper(c.ChoiceName) in ('" + filter.ToUpper() + "') order by q.QuestionId asc";
                    resultQuestion = entityDbModel.Question.SqlQuery(sql).OrderBy(_ => _.QuestionId).Skip(offset).Take(limit).ToList();
                }
                else
                {
                    if (limit >= 0 && offset >= 0)
                    {
                        resultQuestion = entityDbModel.Question.OrderBy(_ => _.QuestionId).Skip(offset).Take(limit).ToList();
                    }
                }
                //take - limit
                //skip - offset 
            return resultQuestion.AsQueryable();
        }
            catch (Exception)
            {

                throw;
            }

        }

    [TestMethod]
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            entityDbModel.Dispose();
        }
        base.Dispose(disposing);
    }

    
    private bool questionExists(int id)
    {
        return entityDbModel.Question.Count(e => e.QuestionId == id) > 0;
    }

    
    private bool choiceExists(int id)
    {
        return entityDbModel.Choice.Count(e => e.QuestionId == id) > 0;
    }

}
}