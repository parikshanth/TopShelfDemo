// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using Autofac;
using AutofacSerilogIntegration;
using Serilog;
using Topshelf;
using Topshelf.Autofac;
using TopShelfDemo;
using TopShelfDemo.SampleDependency;

string loggingTemplate = "{Timestamp:G} [{Level:u3}] [{SourceContext}] {Message}{NewLine:l}{Exception:l}";


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Verbose()
    .Enrich.FromLogContext()
    .WriteTo.Console(outputTemplate: loggingTemplate)
    .CreateLogger();

var buider = new ContainerBuilder();
buider.RegisterLogger();

buider.RegisterType<DemoService>();


//buider.RegisterType<SampleOrange>().As<ISample>();
buider.RegisterType<SampleRed>().As<ISample>();

var container = buider.Build();

HostFactory.Run(x =>
{
    var hostConfig = x.UseAutofacContainer(container);

    x.Service<DemoService>(p =>
    {
        p.ConstructUsingAutofacContainer();
        p.WhenStarted(ds => ds.Start());
        p.WhenStopped(ds => ds.Stop());
    });
    x.UseSerilog(Log.Logger);
    x.RunAsPrompt();
    x.SetDescription("Demo Service using .net core and TopShelf");
    x.SetDisplayName("Demo Service");
    x.SetServiceName("DemoService");

});