//-----------------------------------------------------------------------
// <copyright file="HealthController.cs" company="Bliss Application">
// Copyright (c) Vando Moreira. All rights reserved.
// </copyright>
// <author>Vando.Moreira<author>
// WebApi - Bliss Application
//-----------------------------------------------------------------------
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace api.Controllers
{
    [TestClass]
    // Allow CORS for all origins. (Caution!)
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HealthController : ApiController
    {
        [TestMethod]
        // GET: api/health
        public IEnumerable<string> Get()
        {
            return new string[] { "Status", "OK" };
        }
    }
}
