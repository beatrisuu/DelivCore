﻿using System.Web.Mvc;
using DelivCore.BusinessLayer.ClientService;

namespace DelivCore.Web.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        #region Methods

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult GetClients()
        {
            var clients = _clientService.GetAll();

            return new JsonResult
            {
                Data = new { data = clients },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                ContentType = "application/json"
            };
        }
        #endregion
    }
}