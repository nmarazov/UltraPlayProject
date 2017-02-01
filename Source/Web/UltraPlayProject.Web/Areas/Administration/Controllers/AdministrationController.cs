namespace UltraPlayProject.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using UltraPlayProject.Common;
    using UltraPlayProject.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
    }
}
