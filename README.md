#Create Role-based authorisation with ASP.NET5 Identity 
#Authentication and Authorization using asp.net Identity using user roles in ASP.net C#
#.net 4.7.2

fellow up folling instructions along with the repository for better understanding

## 1. CREATE ROLE WITH ASP.NET IDENTITY

1.1) Open Model and in IdentityModels.cs class add folling code snippet 
//( Models -> IdentityModels.cs) 

//1.1 first step
    //Custom Code By Sithum 
    //for Create a role with asp.net identity

    public class ApplicationRole : IdentityRole
    {  //Custom Code By Sithum
         public ApplicationRole() : base() { }
        public ApplicationRole(string roleName):base(roleName) { }
    }


1.2) Open App_Start and in IdentityConfig.cs class add folling code snippet 
//(App_Start -> IdentityConfig.cs)

//1.2 first step
       //Custom Code By Sithum 
      //for Create a role with asp.net identity
      
            public class ApplicationRoleManager : RoleManager<ApplicationRole>
    { 
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> roleStore) : base(roleStore) { }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            var applicationRoleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context.Get<ApplicationDbContext>()));
            return applicationRoleManager;
        }
    }



1.3) In App_Start folder open Startup.Auth.cs class and in method "public void ConfigureAuth(IAppBuilder app)"method add folling code snippet 
//( App_Start->Startup.Auth.cs->  public void ConfigureAuth(IAppBuilder app) 

   //1.3 Thired step
            //Custom Code By Sithum 
            //for Create a role with asp.net identity

 app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);



1.4) Open Models create model name as "RoleViewModel"and add folowing code 
//(Models->RoleViewModel) 

 //1.4 forth step
    //Custom Code By Sithum 
    //for Create a role with asp.net identity

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

   //1.5 fifth step
        //Custom Code By Sithum 
        //for Create a role with asp.net identity 

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



## 2. Add user to ROLE WITH ASP.NET IDENTITY

2.1) Open Controllers->AccountController and add following code snippet

         //2.1 first step
        //For Add User Role
        //Custom Code By Sithum 

        private ApplicationRoleManager _roleManager;

2.2) In Controllers->AccountController and add following code snippet

	 //2.2 first step
        //For Add User Role
        //Custom Code By Sithum 

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

2.3)In Controllers->AccountController and in Register Method(GET) add following code snippet
  //2.3 Thired step for  Add User to Role
            //For Add User Role
            //Custom Code By Sithum 

            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var role in RoleManager.Roles)
                list.Add(new SelectListItem() { Value = role.Name, Text = role.Name });
            ViewBag.Roles = list;



2.4)In Controllers->AccountController and in Register Method(POST) in Second if statement( if (result.Succeeded))  add following code snippet

 // 2.4 Forth step for  Add User to Role
                    //For Add User Role
                    //Custom Code By Sithum 

                    result = await UserManager.AddToRoleAsync(user.Id,model.RoleName);

2.5) in Models->AccountViewModel in RegisterViewModel add Following Code snippet

 // 2.5 fifth step for  Add User to Role
        //For Add User Role
        //Custom Code By Sithum 
        public string RoleName { get; set; }


2.6) In Views -> Register add following Code snippet
    // 2.6 sixth step for  Add User to Role
    //For Add User Role
    //Custom Code By Sithum
    @Html.ValidationSummary("", new { @class = "text-danger" })
    <div class="form-group">
        @Html.LabelFor(m => m.RoleName, new { @class = "col-md-2 control-label" })
        <div class="col-md-10">
          @Html.DropDownListFor(m=> m.RoleName, new SelectList(ViewBag.Roles,"Value","Text",new { @class = "form-control"}))
        </div>
    </div>
    
    ##Add Global authorized attribute for all Controllers
3)Add Global authorized attribute for all Controllers

In App_Start Open FilterConfig and add following Code Snippet to RegisterGlobalFilters method

            //Add Global authorized attribute for all Controllers
            //Custom Code Snippet By Sithum
            filters.Add(new AuthorizeAttribute());

	##Add Local authorized attribute to Controller
4) Add Local authorized attribute to Controller
	//Add following Code Snippet to any controller with role name
 [Authorize(Roles = "Admin")]
	
	##Add Custom Authorize Attribute To Soluction 
5)Add Custom Authorize Attribute To Solution  
	

5) Add Custom Authorize Attribute To Soluction 
5.1)Add CustomAuthorizeAttribute.cs to Solution  with following code snippet


 [AttributeUsage(AttributeTargets.Method)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {

        public string ViewName { get; set; }


        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            IsUserAuthorized(filterContext);
        }

        void IsUserAuthorized(AuthorizationContext filterContext)
        {
            //user is authorized
            if (filterContext.Result == null)
                return;
           if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            { 
            ViewDataDictionary dictionary = new ViewDataDictionary();
                dictionary.Add("Message","You Are Not Autherized!");
                var result = new ViewResult() { ViewName = this.ViewName, ViewData = dictionary };
                filterContext.Result = result;
            }
        }

    }

5.2) add following code snippet to above the controller you want
 [CustomAuthorize(Roles = "Admin")]






