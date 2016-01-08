using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using rc.Repository.Interface;
using rc.Repository.Repository;
using rc.Repository;
using rc.ServiceLayer.Interfaces;
using rc.ServiceLayer;
using Microsoft.AspNet.Identity;
using rc.UserInterface.MVC.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using rc.UserInterface.MVC.Controllers;

namespace rc.UserInterface.MVC.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IDatabaseFactory, DatabaseFactory>(new PerRequestLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new PerRequestLifetimeManager());

            container.RegisterType<ICustomerRepository, CustomerRepository>();
            container.RegisterType<ICustomerService, CustomerService>();
            container.RegisterType<IGPRepository, GPRepository>();
            container.RegisterType<IGPService, GPService>();

            container.RegisterType<IWardRepository, WardRepository>();
            container.RegisterType<IWardService, WardService>();

            container.RegisterType<IPatientAdmissionRepository, PatientAdmissionRepository>();
            container.RegisterType<IPatientService, PatientService>();

            container.RegisterType<IPatientDailyDiaryRepository, PatientDailyDiaryRepository>();
            container.RegisterType<IPatientDailyDiaryService, PatientDailyDiaryService>();

            container.RegisterType<ICarePlanRepository, CarePlanRepository>();
            container.RegisterType<ICarePlanService, CarePlanService>();

            container.RegisterType<IPatientVitalSignRepository, PatientVitalSignRepository>();
            container.RegisterType<IPatientVitalSignService, PatientVitalSignService>();

            container.RegisterType<IAssesmentQuestionService, AssesmentQuestionService>();
            container.RegisterType<IAssesmentQuestionRepository, AssesmentQuestionRepository>();

            container.RegisterType<IStaffProfileService, StaffProfileService>();
            container.RegisterType<IStaffProfileRepository, StaffProfileRepository>();

            container.RegisterType<IPatientAppointmentService, PatientAppointmentService>();
            container.RegisterType<IPatientAppointmentRepository, PatientAppointmentRepository>();


            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            container.RegisterType<UserManager<ApplicationUser>>();
            container.RegisterType<DbContext, ApplicationDbContext>();
            container.RegisterType<ApplicationUserManager>();
            container.RegisterType<AccountController>(new InjectionConstructor(typeof(ICustomerService),typeof(IStaffProfileService)));
            //container.RegisterType<AccountController>(new InjectionConstructor());
        }
    }
}
