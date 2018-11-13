//-----------------------------------------------------------------------
// <copyright file="ShareController.cs" company="Bliss Application">
// Copyright (c) Vando Moreira. All rights reserved.
// </copyright>
// <author>Vando.Moreira<author>
// WebApi - Bliss Application
//-----------------------------------------------------------------------
using api.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using System.Web.Http.Cors;

namespace api.Controllers
{
    [TestClass]
    // Allow CORS for all origins. (Caution!)
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ShareController : ApiController
    {
        private Email email = new Email();

        [TestMethod]
        // GET: api/share?destination_email={destination_email}&content_url={content_url}
        public IHttpActionResult Postemail(string destinationEmail, string contentUrl)
        {

            if (destinationEmail != null && destinationEmail != null)
                email.sendEmailViaWebApi(destinationEmail, contentUrl);

            return StatusCode(HttpStatusCode.NoContent);
        }

    }


}
