using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.CSharp;

// ReSharper disable LocalizableElement

namespace OzCodeDemo
{
    /// <summary>
    /// Interaction logic for InvokeGeneratedProcess.xaml
    /// </summary>
    public partial class InvokeGeneratedProcess
    {
        public InvokeGeneratedProcess()
        {
            InitializeComponent();
        }

        private async void StartNewProcess(object sender, RoutedEventArgs e)
        {
            string message = HelloText.Text;
            var path = GenerateProcess(message, true);
            if (path == null)
                throw new SyntaxErrorException("Can't generate code");

            var process = StartProcessAndWait(path);
            App.Output.Lines.Add("Start another instance of Visual Studio." + Environment.NewLine + 
                            "Using Visual Studio Dialog, attach to process: " + path + Environment.NewLine + 
                            " id: " + process.Id + Environment.NewLine +
                            "Debug it and stop debugging and kill the process." + Environment.NewLine +
                            "Press OK, We are waiting...");
            await Task.Run(()=>process.WaitForExit());
            App.Output.Lines.Add("Great!, OzCode remembers your debugger attached processes." + Environment.NewLine +
                            "We are going to start a new instance of: " + path + Environment.NewLine +
                            "Now use OzCode Quick Process Attach to attach again to the process." + Environment.NewLine +
                            "Debug it and stop debugging and kill the process again" + Environment.NewLine +
                            "Press OK, We are waiting...");

            process = StartProcessAndWait(path);
            await Task.Run(() => process.WaitForExit());
            Close();
        }

        private static Process StartProcessAndWait(string path)
        {
            var process = new Process
                          {
                              StartInfo = new ProcessStartInfo
                                          {
                                              FileName = path
                                          }
                          };
            process.Start();

            return process;
        }

        private string GenerateProcess(string message, bool debug)
        {
            var ccu = new CodeCompileUnit();

			// create a namespace
			var ns = new CodeNamespace("HelloOzCodeDemo");

			// create a class
			var helloClass = new CodeTypeDeclaration("Hello") 
                {IsClass = true, Attributes = MemberAttributes.Assembly};

		    // create the Main method
            // ReSharper disable once BitwiseOperatorOnEnumWithoutFlags
			var main = new CodeMemberMethod
			           {
			               Name = "Main",
			               ReturnType = new CodeTypeReference(typeof (void)),
			               Attributes = MemberAttributes.Public | MemberAttributes.Static
			           };


            // Declares and initializes an integer variable named i.
            var i = new CodeVariableDeclarationStatement(typeof(int), "i", new CodePrimitiveExpression(0) );
            main.Statements.Add(i);

            // Creates a for loop that sets testInt to 0 and continues incrementing testInt by 1 each loop until testInt is not less than 10.
            var forLoop = new CodeIterationStatement(
            // initStatement parameter for pre-loop initialization. 
                new CodeAssignStatement( 
                    new CodeVariableReferenceExpression("i"), new CodePrimitiveExpression(0) ),
                        // testExpression parameter to test for continuation condition. 
                        new CodeBinaryOperatorExpression( 
                            new CodeVariableReferenceExpression("i"), 
                                CodeBinaryOperatorType.LessThan, new CodePrimitiveExpression(100000)),
                                    // incrementStatement parameter indicates statement to execute after each iteration. 
                                    new CodeAssignStatement( 
                                        new CodeVariableReferenceExpression("i"), 
                                            new CodeBinaryOperatorExpression( 
                                                new CodeVariableReferenceExpression("i"), 
                                                    CodeBinaryOperatorType.Add, 
                                                        new CodePrimitiveExpression(1) )),
            // statements parameter contains the statements to execute during each interaction of the loop. 
            new CodeStatement[] { new CodeExpressionStatement( 
                new CodeMethodInvokeExpression( 
                    new CodeMethodReferenceExpression( 
                        new CodeTypeReferenceExpression("System.Console"), "WriteLine" ),  
                            new CodePrimitiveExpression(message) ) ),
                new CodeExpressionStatement(
                    new CodeMethodInvokeExpression( 
                        new CodeMethodReferenceExpression( 
                            new CodeTypeReferenceExpression("System.Threading.Thread"), "Sleep" ),
                                new CodePrimitiveExpression(100)))
            
            } );

            main.Statements.Add(forLoop);
			
			// add the method to the class
			helloClass.Members.Add(main);

			// add the class to the namespace
			ns.Types.Add(helloClass);

			// add the namespace to the code-compile unit
			ccu.Namespaces.Add(ns);

			// prepare for compilation
            CodeDomProvider csc = new CSharpCodeProvider();

            var sourcePath = Path.Combine(Path.GetTempPath(),"___HelloOzCode.cs");
            
            var executablePath = Path.ChangeExtension(sourcePath, "exe");

			var cp = new CompilerParameters
			         {
			             GenerateExecutable = true,
			             GenerateInMemory = false,
                         CompilerOptions = debug ? "/debug" : "/optimize",
                         OutputAssembly = executablePath,
                         IncludeDebugInformation = debug
			         };

            using (var sourceFile = File.CreateText(sourcePath))
            {
                csc.GenerateCodeFromCompileUnit(ccu, sourceFile,
                    new CodeGeneratorOptions {BracingStyle = "C"});
            }
		    // compile!
			CompilerResults result = csc.CompileAssemblyFromFile(cp, sourcePath);
			if(result.Errors.Count > 0)
			{
			    var sb = new StringBuilder();
				sb.AppendLine("Errors in compilation:");
				foreach(CompilerError err in result.Errors)
					sb.AppendLine(err.ToString());
			    App.Output.Lines.Add(sb.ToString());

			    return null;
			}

            return executablePath;
        }
    }
}
