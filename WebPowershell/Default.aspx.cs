using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;

namespace ITDropletsPowershell
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Note: Part of this code was taken a long time ago from http://jeffmurr.com/blog/?p=142.
        protected void ExecuteInputClick(object sender, EventArgs e)
        {
            // First of all, let's clean the TextBox from any previous output
            Result.Text = string.Empty;
            //Result.Text = string.Empty;
            // Create the InitialSessionState Object
            InitialSessionState iss = InitialSessionState.CreateDefault();
            //iss.ExecutionPolicy = Microsoft.PowerShell.ExecutionPolicy.Unrestricted;
            //In our specific case we don't need to import any module, but I'm adding these two lines below
            //to show where we would import a Module from Path.
            iss.ImportPSModulesFromPath("C:\\Program Files\\WindowsPowerShell\\Modules\\VMware.Vim");
            //iss.ImportPSModulesFromPath("C:\\inetpub\\LocalScriptsAndModules\\MyOtherModule2");


            // Initialize PowerShell Engine
            var shell1 = PowerShell.Create(iss);

            // Add the command to the Powershell Object, then add the parameter from the text box with ID Input
            //The first one is the command we want to run with the input, so Get-ChildItem is all we need
            //shell.Commands.AddCommand("get-children");
            //shell.Commands.AddCommand("command", Input.Text);
            shell1.Commands.AddCommand("Get-VIServer");
            //Now we're adding the variable (so the directory) chosen by the user of the web application
            //Note that "Path" below comes from Get-ChildItem -Directory and Input.Text it's what the user typed
            shell1.Commands.AddParameter("Path", Input.Text);

            // Initialize PowerShell Engine
            var shell2 = PowerShell.Create(iss);

            // Add the command to the Powershell Object, then add the parameter from the text box with ID Input
            //The first one is the command we want to run with the input, so Get-ChildItem is all we need
            shell2.Commands.AddCommand("Get-ChildItem");
            //Now we're adding the variable (so the directory) chosen by the user of the web application
            //Note that "Path" below comes from Get-ChildItem -Directory and Input.Text it's what the user typed
            shell2.Commands.AddParameter("Path", Input.Text);

            // Execute the script 
            try
            {
                var results = shell1.Invoke();

                // display results, with BaseObject converted to string
                // Note : use |out-string for console-like output
                if (results.Count > 0)
                {
                    // We use a string builder ton create our result text
                    var builder = new StringBuilder();

                    foreach (var psObject in results)
                    {
                        // Convert the Base Object to a string and append it to the string builder.
                        // Add \r\n for line breaks
                        builder.Append(psObject.BaseObject.ToString() + "\r\n");
                    }

                    // Encode the string in HTML (prevent security issue with 'dangerous' caracters like < >
                    Result.Text = Server.HtmlEncode(builder.ToString());
                }
            }
            catch (ActionPreferenceStopException Error) { Result.Text = Error.Message; }
            catch (RuntimeException Error) { Result.Text = Error.Message; };

            // Execute the script 
            try
            {
                var results = shell2.Invoke();

                // display results, with BaseObject converted to string
                // Note : use |out-string for console-like output
                if (results.Count > 0)
                {
                    // We use a string builder ton create our result text
                    var builder = new StringBuilder();

                    foreach (var psObject in results)
                    {
                        // Convert the Base Object to a string and append it to the string builder.
                        // Add \r\n for line breaks
                        builder.Append(psObject.BaseObject.ToString() + "\r\n");
                    }

                    // Encode the string in HTML (prevent security issue with 'dangerous' caracters like < >
                    Result.Text = Server.HtmlEncode(builder.ToString());
                }
            }

            catch (ActionPreferenceStopException Error) { Result.Text = Error.Message; }
            catch (RuntimeException Error) { Result.Text = Error.Message; };
        }


    }
}