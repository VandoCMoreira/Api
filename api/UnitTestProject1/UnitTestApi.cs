//-----------------------------------------------------------------------
// <copyright file="UnitTestApi.cs" company="Bliss Application">
// Copyright (c) Vando Moreira. All rights reserved.
// </copyright>
// <author>Vando.Moreira<author>
// WebApi - Bliss Application
//-----------------------------------------------------------------------

using Microsoft.VisualStudio.TestTools.UnitTesting;
using api.Controllers;
using api.Models;
using System.Web.Http.Results;
using System.Linq;
using System.Web.Http;
using System.Collections.Generic;



namespace UnitTestApi
{
    [TestClass]
    public class UnitTestApi
    {

        [TestMethod]
        public void GetQuestionIdInt() //crud Question
        {
           var controller = new QuestionController();
           var Response = controller.Getquestion(1);
            var contentResult = Response as OkNegotiatedContentResult<Question>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.QuestionId);

        }

        public void GetQuestionIdChar() 
        {
            var controller = new QuestionController();
            IHttpActionResult actionResult = controller.Getquestion('x');
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetQuestionText() 
        {
            var controller = new QuestionController();
            var response = controller.Getquestion('x');
            IHttpActionResult actionResult = controller.Getquestion('x');
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
       }

        [TestMethod]
        public void GetQuestion() 
        {
            QuestionController controller = new QuestionController();
            IQueryable<Question> actionResult = controller.Getquestion();
            Assert.IsNotNull(actionResult);
            Assert.IsTrue(actionResult.Count() > 0);
        }

        [TestMethod]
        public void Putquestion() 
        {
            QuestionController controller = new QuestionController();
            IHttpActionResult actionResult = controller.Putquestion(1, new Question { QuestionId = 1, QuestionName = null, ImageUrl = null, Choices = null});
            Assert.IsInstanceOfType(actionResult, typeof(StatusCodeResult));
        }

        [TestMethod]
        public void PutquestionChar() 
        {
            QuestionController controller = new QuestionController();
            IHttpActionResult actionResult = controller.Putquestion(' ', new Question { QuestionId = 1, QuestionName = null, ImageUrl = null, Choices = null });
            Assert.IsInstanceOfType(actionResult, typeof(StatusCodeResult));
        }

        [TestMethod]
        public void PutquestionStr() 
        {
            QuestionController controller = new QuestionController();
            IHttpActionResult actionResult = controller.Putquestion('x', new Question { QuestionId = 1, QuestionName = null, ImageUrl = null, Choices = null });
            Assert.IsInstanceOfType(actionResult, typeof(StatusCodeResult));
        }

        [TestMethod]
        public void PutquestionInt() 
        {
            QuestionController controller = new QuestionController();
            IHttpActionResult actionResult = controller.Putquestion(10000, new Question { QuestionId = 1, QuestionName = null, ImageUrl = null, Choices = null });
            Assert.IsInstanceOfType(actionResult, typeof(StatusCodeResult));
        }

        [TestMethod]
        public void PutquestionChoice() 
        {
            QuestionController controller = new QuestionController();
            IHttpActionResult actionResult = controller.Putquestion(10000, null);
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void Postquestion() 
        {
            QuestionController controller = new QuestionController();
            IHttpActionResult actionResult = controller.Postquestion(null);
            var createResult = actionResult as OkNegotiatedContentResult<QuestionDTO>;
            Assert.IsInstanceOfType(actionResult, typeof(InvalidModelStateResult));
        }

        [TestMethod]
        public void PostquestionObj()
        {
            QuestionController controller = new QuestionController();
            IHttpActionResult actionResult = controller.Postquestion(new QuestionDTO { } );
            var createResult = actionResult as CreatedAtRouteNegotiatedContentResult<Question>;
            Assert.IsInstanceOfType(actionResult, typeof(CreatedAtRouteNegotiatedContentResult<Question>));
        }

        [TestMethod]
        public void GetFilterQuestion() 
        {
            QuestionController controller = new QuestionController();
            IQueryable<Question> actionResult = controller.GetFilterQuestion(-1, -1, null);
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(EnumerableQuery));
        }

        [TestMethod]
        public void GetFilterQuestionCharLimit()
        {
            QuestionController controller = new QuestionController();
            IQueryable<Question> actionResult = controller.GetFilterQuestion(' ', -1, null);
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(EnumerableQuery));
        }

        [TestMethod]
        public void GetFilterQuestionCharCharOffSet()
        {
            QuestionController controller = new QuestionController();
            IQueryable<Question> actionResult = controller.GetFilterQuestion(' ', ' ', null);
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(EnumerableQuery));
        }

        [TestMethod]
        public void GetFilterQuestionCharCharFilter()
        {
            QuestionController controller = new QuestionController();
            IQueryable<Question> actionResult = controller.GetFilterQuestion(' ', ' ', " ");
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(EnumerableQuery));
        }

        [TestMethod]
        public void GetHealth() 
        {
            HealthController controller = new HealthController();
            IEnumerable<string> actionResult = controller.Get();
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(System.String[]));
        }
    
    }
}
