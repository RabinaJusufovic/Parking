using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using parking.database.Models;
using parking.dataAccess.Repositories;
using parking.dataAccess.Repositories.Contracts;
using parking.Queries;
using parking.Schema;
using parking.types;
using parking.dataAccess;
using parking.Mutations;

namespace parking
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddEntityFrameworkNpgsql().AddDbContext<MyWebApiContext>(opt =>
            opt.UseNpgsql(Configuration.GetConnectionString("MyWebApiConnection")));

            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

            services.AddSingleton<UserQuery>();
            services.AddSingleton<CommentsType>();
            services.AddSingleton<UserQuery>();
            services.AddSingleton<UserType>();
            services.AddSingleton<UserMutation>();
            services.AddSingleton<UserInputType>();
#pragma warning disable ASP0000 // Do not call 'IServiceCollection.BuildServiceProvider' in 'ConfigureServices'
            var sp = services.BuildServiceProvider();
#pragma warning restore ASP0000 // Do not call 'IServiceCollection.BuildServiceProvider' in 'ConfigureServices'
            services.AddSingleton<ISchema>(new ParkingSchema(new FuncDependencyResolver(type => sp.GetService(type))));
            services.AddGraphQL().AddGraphTypes(ServiceLifetime.Scoped);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseMvc();
            //app.UseGraphiQl();

            app.UseGraphQL<ISchema>();
            app.UseGraphQLPlayground
               (new GraphQLPlaygroundOptions());
        }
    }
}
