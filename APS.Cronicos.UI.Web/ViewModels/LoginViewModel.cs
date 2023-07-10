﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace APS.Cronicos.UI.Web.ViewModels
{
    public class LoginViewModel
    {
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public bool FlRelembrar { get; set; }
        public int? IdUnidade { get; set; }
        public List<SelectListItem> ListarUnidades { get; set; } = new List<SelectListItem>();
    }
}
