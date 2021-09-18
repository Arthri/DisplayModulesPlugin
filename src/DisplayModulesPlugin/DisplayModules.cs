using System;
using System.Linq;
using System.Reflection;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;

namespace DisplayModulesPlugin
{
    [ApiVersion(2, 1)]
    public class DisplayModules : TerrariaPlugin
    {
        public override string Name => Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyTitleAttribute>().Title;

        public override string Description => Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyDescriptionAttribute>().Description;

        public override Version Version => Assembly.GetExecutingAssembly().GetName().Version;

        public override string Author => Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyCompanyAttribute>().Company;

        public DisplayModules(Main game) : base(game)
        {
        }

        public override void Initialize()
        {
            Commands.ChatCommands.Add(new Command("displaymodules.displaymodules", HandleDisplayModules, "displaymodules", "dmods", "showmods"));
        }

        private void HandleDisplayModules(CommandArgs e)
        {
            int page = 1;
            if (e.Parameters.Count > 0)
            {
                if (!int.TryParse(e.Parameters[0], out page))
                {
                    e.Player.SendErrorMessage("Invalid page");
                    return;
                }
            }
            else if (e.Parameters.Count > 1)
            {
                e.Player.SendErrorMessage("Too many arguments specified");
                return;
            }

            var moduleTerms = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.IsDynamic)
                .Select(a => $"{a.GetCustomAttribute<AssemblyTitleAttribute>().Title}({a.GetName().Version})");
            var lines = PaginationTools.BuildLinesFromTerms(moduleTerms);
            PaginationTools.SendPage(
                e.Player,
                page,
                lines);
        }
    }
}
