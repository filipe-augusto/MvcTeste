using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcTeste.Filters
{
    public class LogActionFiltercs : ActionFilterAttribute
    {
            //quando começar a ser executada
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log("OnActionExecuting", filterContext.RouteData);
        }
        //depois da chamada
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
          
            Log("OnActionExecuting", filterContext.RouteData);
        }
        //depois do retorno da acton
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Log("OnResultExecuted", filterContext.RouteData);
          
        }

   
        //executado antes do retorno do resultado
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Log("OnResultExecuting", filterContext.RouteData);
        }

        private void Log(string method, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = string.Format("{0} controller:{1} action: {2}", method,controllerName, actionName
                );

            Debug.WriteLine(message, "Action filter log");
        }
       
    }
}