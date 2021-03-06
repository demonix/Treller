﻿using System;

namespace SKBKontur.Treller.WebApplication.Implementation.Services.News.Content.Parsing
{
    public interface IContentParser
    {
        Content Parse(Guid sourceId, string title, string desc, DateTime? deadLine);
    }
}