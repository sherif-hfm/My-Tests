using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AppFunc = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;
namespace CreatingMiddlewareWithOWIN.Middleware
{
    public class DebugMiddleware
    {

        private AppFunc _next;
        private DebugMiddlewareOptions _options;
        public DebugMiddleware(AppFunc next, DebugMiddlewareOptions options)
        {
            _next = next;
            _options = options;
            if (_options.OnInRequest == null)
                _options.OnInRequest = (ctx) => { Debug.WriteLine("In Request1 " + ctx.Request.Path); };

            if (_options.OnOutRequest == null)
                _options.OnOutRequest = (ctx) => { Debug.WriteLine("Out Request1 " + ctx.Request.Path); };

        }

        public async Task Invoke(IDictionary<string, object> env)
        {
            var ctx = new OwinContext(env);
            _options.OnInRequest(ctx);
            await _next(env);
            _options.OnOutRequest(ctx);
        }
    }
}