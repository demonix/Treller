﻿using SKBKontur.Treller.WebApplication.Implementation.Infrastructure.Abstractions;
using SKBKontur.Treller.WebApplication.Implementation.TaskList.BusinessObjects.ViewModels;

namespace SKBKontur.Treller.WebApplication.Implementation.TaskList.BusinessObjects.Blocks
{
    public class BaseCardListBlock : BaseBlock
    {
        public CardListEnterModel EnterModel { get; set; }
    }
}