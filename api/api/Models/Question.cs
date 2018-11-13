//-----------------------------------------------------------------------
// <copyright file="Question.cs" company="Bliss Application">
// Copyright (c) Vando Moreira. All rights reserved.
// </copyright>
// <author>Vando.Moreira<author>
// WebApi - Bliss Application
//-----------------------------------------------------------------------
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace api.Models
{
    [TestClass]
    [JsonObject(MemberSerialization.OptIn)]
    public partial class Question
    {

        public Question()
        {
            PublishedAt = DateTime.UtcNow;
        }

        [Key]
        [JsonProperty("id")]
        public int QuestionId { get; set; }
        [JsonProperty("question")]
        public string QuestionName { get; set; }
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
        [JsonProperty("thumb_url")]
        public string ThumbUrl { get; set; }
        [JsonProperty("published_at") ]
        public DateTime? PublishedAt { get; set; }
        [JsonProperty("choices")]
        public virtual ICollection<Choice> Choices { get; set; }
    }

    [TestClass]
    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public  class QuestionDTO
    {
        public QuestionDTO()
        {
            PublishedAt = DateTime.UtcNow;
        }

        [JsonProperty("id")]
        public int QuestionDTOId { get; set; }
        [JsonProperty("question")]
        public string QuestioDTOName { get; set; }
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
        [JsonProperty("thumb_url")]
        public string ThumbUrl { get; set; }
        //[JsonProperty("published_at")]
        public DateTime? PublishedAt { get; set; }
        [JsonProperty("choices")]
        public string[] Choices { get; set; }

    }


}
