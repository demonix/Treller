﻿using System;
using System.Linq;
using System.Web.Mvc;
using SKBKontur.Treller.WebApplication.Services.VirtualMachines.BusinessObjects;
using SKBKontur.Treller.WebApplication.Services.VirtualMachines.Logging;
using SKBKontur.Treller.WebApplication.Services.VirtualMachines.Services;
using SKBKontur.Treller.WebApplication.Services.VirtualMachines.Storages;

namespace SKBKontur.Treller.WebApplication.Controllers
{
    public class VirtualMachinesController : Controller
    {
        private readonly IVirtualMachinesStorage virtualMachinesStorage;
        private readonly IVirtualMachinesService virtualMachinesService;
        private readonly IVirtualMachinesExecuteLog virtualMachinesExecuteLog;

        public VirtualMachinesController(IVirtualMachinesStorage virtualMachinesStorage, IVirtualMachinesService virtualMachinesService,
                                         IVirtualMachinesExecuteLog virtualMachinesExecuteLog)
        {
            this.virtualMachinesStorage = virtualMachinesStorage;
            this.virtualMachinesService = virtualMachinesService;
            this.virtualMachinesExecuteLog = virtualMachinesExecuteLog;
        }

        [HttpGet]
        public ActionResult Index(bool isLoginFailed = false, string command = null)
        {
            var machines = virtualMachinesStorage.GetAllVirtualMachines();
            ViewData["isLoginFailed"] = isLoginFailed;
            ViewData["command"] = command;
            return View("Index", machines);
        }

        [HttpPost]
        public ActionResult ExecuteCommand(string command, string login, string[] virtualMachineNames)
        {
            if (login != "mayloe" && login != "yord")
            {
                return RedirectToAction("Index", new {isLoginFailed = true});
            }

            virtualMachineNames = virtualMachineNames.Where(x => x != "false").ToArray();
            var executeId = virtualMachinesService.ExecuteCommandAsync(command, login, virtualMachineNames);

            return RedirectToAction("ShowLogs", new { ExecuteId = executeId });
        }

        [HttpGet]
        public ActionResult ShowLogs(Guid? executeId, Guid? refreshExecuteId = null)
        {
            if (refreshExecuteId.HasValue)
            {
                virtualMachinesService.RefreshExecuteCommandProgress(refreshExecuteId.Value);
            }
            CommandExecuteResult commandResult = null;
            if (executeId.HasValue)
            {
                commandResult = virtualMachinesService.GetExecuteCommandProgress(executeId.Value) ??
                                virtualMachinesExecuteLog.FindLog(executeId.Value).Execute;
            }
            

            var lastLogs = virtualMachinesExecuteLog.SelectLastLogs(10);

            var resultModel = new ShowLogsViewModel
            {
                CurrentResult = commandResult,
                Logs = lastLogs
            };

            return View("ShowLogs", resultModel);
        }

        public ActionResult DeleteLogs()
        {
            virtualMachinesExecuteLog.DeleteAll();

            return RedirectToAction("Index");
        }
    }
}