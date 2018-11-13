//-----------------------------------------------------------------------
// <copyright file="Choice.cs" company="Bliss Application">
// Copyright (c) Vando Moreira. All rights reserved.
// </copyright>
// <author>Vando.Moreira<author>
// WebApi - Bliss Application
//-----------------------------------------------------------------------
namespace api.Models
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    [TestClass]
    [JsonObject(MemberSerialization.OptIn)]
    public partial class Choice
    {
        [Key]
        [JsonProperty("choiceid")]
        public int ChoiceId { get; set; }

        [JsonProperty("choice")]
        public string ChoiceName { get; set; }

        [JsonProperty("votes")]
        public int Votes { get; set; }

        [JsonProperty]
        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }

    }
}
