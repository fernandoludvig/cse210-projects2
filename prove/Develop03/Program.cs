using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Create a scripture instance
        Scripture john316 = new Scripture("John 3:16", "For God so loved the world...");

        // Create a console-based scripture viewer
        ScriptureViewer viewer = new ConsoleScriptureViewer(john316);

        // Run the viewer
        viewer.Run();
    }
}