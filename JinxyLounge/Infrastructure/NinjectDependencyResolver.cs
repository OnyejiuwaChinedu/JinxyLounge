using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moq;
using Ninject;
using JinxyLounge.Domain.Abstract;
using JinxyLounge.Domain.Entities;
using JinxyLounge.Domain.Concrete;

namespace JinxyLounge.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {      
            private IKernel kernel;
            public NinjectDependencyResolver(IKernel kernelParam)
            {
                kernel = kernelParam;
                AddBindings();
            }
            public object GetService(Type serviceType)
            {
                return kernel.TryGet(serviceType);
            }
            public IEnumerable<object> GetServices(Type serviceType)
            {
                return kernel.GetAll(serviceType);
            }
            private void AddBindings()
            {
            kernel.Bind<IProductRepository>().To<EFProductRepository>();
            kernel.Bind<IEmployeeTypeRepository>().To<EFEmployeeTypeRepository>();
            kernel.Bind<IEmployeeRepository>().To<EFEmployeeRepository>();
            kernel.Bind<IPaymentRepository>().To<EFPaymentRepository>();
            kernel.Bind<ICustomerRepository>().To<EFCustomerRepository>();
            kernel.Bind<IOrderRepository>().To<EFOrderRepository>();
            kernel.Bind<IInvoiceRepository>().To<EFInvoiceRepository>();


        }
    }   
}
