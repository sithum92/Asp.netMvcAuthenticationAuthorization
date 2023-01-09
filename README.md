#Create Role-based authorisation with ASP.NET5 Identity 
#Authentication and Authorization using asp.net Identity using user roles in ASP.net C#
#.net 4.7.2

fellow up folling instructions along with the repository for better understanding

## 1. CREATE ROLE WITH ASP.NET IDENTITY

1.1) Open Model and in IdentityModels.cs class add folling code snippet 
//( Models -> IdentityModels.cs) 
//Custom Code By Sithum

    public class ApplicationRole : IdentityRole
    {  //Custom Code By Sithum
         public ApplicationRole() : base() { }
        public ApplicationRole(string roleName):base(roleName) { }
    }


1.2) Open App_Start and in IdentityConfig.cs class add folling code snippet 
//(App_Start -> IdentityConfig.cs)

            public class ApplicationRoleManager : RoleManager<ApplicationRole>
    { //Custom Code By Sithum
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> roleStore) : base(roleStore) { }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            var applicationRoleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context.Get<ApplicationDbContext>()));
            return applicationRoleManager;
        }
    }



1.3) In App_Start folder open Startup.Auth.cs class and in method "public void ConfigureAuth(IAppBuilder app)"method add folling code snippet 
//( App_Start->Startup.Auth.cs->  public void ConfigureAuth(IAppBuilder app) 
//Custom Code By Sithum

 app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);



1.4) Open Models create model name as "RoleViewModel"and add folowing code 
//(Models->RoleViewModel) 
//Custom Code By Sithum

 public class RoleViewModel
    {
        public RoleViewModel() { }

        public RoleViewModel(ApplicationRole role)
        {
            Id = role.Id;
            Name = role.Name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }


1.5) Open Controllers ans add controller name as "RoleController" and add folowing code 
//(Controllers->RoleController.cs)
//Custom Code By Sithum

    public class RoleController : Controller
    {

         private ApplicationRoleManager _roleManager;

        public RoleController()
        {
                
        }

        public RoleController(ApplicationRoleManager roleManager)
        {
           RoleManager = roleManager;

        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }


  public ActionResult Index()   //Add View For This
        {
            List<RoleViewModel> list = new List<RoleViewModel>();
            foreach (var role in RoleManager.Roles)
                list.Add(new RoleViewModel(role));
            return View(list);
        }

        public ActionResult Create()  // Don’t Add View For This

        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(RoleViewModel model)  //Add View For This

        {
            var role = new ApplicationRole() { Name = model.Name };
            await RoleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(string id)  // Don’t Add View For This
        {
            var role = await RoleManager.FindByIdAsync(id);
            return View(new RoleViewModel(role));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(RoleViewModel model)  //Add View For This

        {
            var role = new ApplicationRole() { Id = model.Id, Name = model.Name };
            await RoleManager.UpdateAsync(role);
            return RedirectToAction("Index");
        }


        public async Task<ActionResult> Details(string id)   //Add View For This

        {
            var role = await RoleManager.FindByIdAsync(id);
            return View(new RoleViewModel(role));
        }


        public async Task<ActionResult> Delete(string id)   //Add View For This
        {
            var role = await RoleManager.FindByIdAsync(id);
            return View(new RoleViewModel(role));
        }


        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            await RoleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }
}
}




