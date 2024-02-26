using LexicalAnalyzer;
using Syntax_Analyzer;
using static System.Net.Mime.MediaTypeNames;

namespace WinFormsApp1;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        syntax.Enabled = false;
        semantic.Enabled = false;
    }

    Analyzer lex = new Analyzer();
    Initializer Lexical = new Initializer();
    string txt;
    List<int> linetokens = new List<int>();
    List<string> intList = new List<string>();
    List<string> doubleList = new List<string>();
    List<string> stringList = new List<string>();
    List<string> boolList = new List<string>();

    private void lexer_Click(object sender, EventArgs e)
    {
        LexGrid.Rows.Clear();
        DataLexicalError.Rows.Clear();
        DataSyntaxError.Rows.Clear();
        syntax.Enabled = false;
        semantic.Enabled = false;

        tabControl1.SelectTab("tabPage1");
        tabControl2.SelectTab("tabPage3");

        if (Code.RichTextBox.Text != "")
        {
            txt = Code.RichTextBox.Text;

            lex = Lexical.InitializeAnalyzer(txt, lex);

            DisplayTokens(lex);

            if (lex._invalid == 0 && lex._token.Count != 0)
            {
                syntax.Enabled = true;
            }
            else
            {
                syntax.Enabled = false;
                semantic.Enabled = false;
            }
        }
    }

    private void syntax_Click(object sender, EventArgs e)
    {
        SyntaxInitializer syntaxInitializer = new SyntaxInitializer();
        DataSyntaxError.Rows.Clear();

        int i = 1;
        string s;

        tabControl2.SelectTab("tabPage4");

        s = syntaxInitializer.Start(tokenDump(lex._token));

        if (s != "Analyzer has pushed the lane. Proceed!")
        {
            int errornum = 1;
            DataSyntaxError.Rows.Clear();

            if (syntaxInitializer.errors.getColumn() == 1)
            {
                syntaxInitializer.errors.setLines(syntaxInitializer.errors.getLines() - 1);
            }

            DataSyntaxError.Rows.Add(errornum, syntaxInitializer.errors.getLines(), syntaxInitializer.errors.getErrorMessage());

            errornum++;
        }
        else
        {
            DataSyntaxError.Rows.Add(i, "", s);
            semantic.Enabled = true;
        }
    }

    private void DisplayTokens(Analyzer lex)
    {
        string result = "You may push!";
        int ctr = 0, id = 0, error = 0;
        LexGrid.Rows.Clear();
        DataLexicalError.Rows.Clear();

        if (lex._invalid != 0)
            result = "Pinging " + lex._invalid.ToString() + " error/s. QUEUE AGAIN!";

        DataLexicalError.Rows.Add(id, "Lexical Analyzer: " + result);

        foreach (var token in lex._token)
        {
            if (token.getTokens() == "Invalid")
            {
                error++;
                DataLexicalError.Rows.Add(error, "Invalid lexeme: "
                            + token.getLexemes()
                            + " on line "
                            + token.getLines());
            }
            else if (token.getTokens() == "NoDelim")
            {
                error++;
                DataLexicalError.Rows.Add(error, "Proper delimiter expected: "
                            + token.getLexemes()
                            + " on line "
                            + token.getLines());
            }
            else
            {
                id++;
                LexGrid.Rows.Add(id, token.getLexemes(), token.getTokens());
            }
            ctr++;
        }
    }

    public List<TokenLibrary.TokensClass> tokenDump(List<Tokens> tokens)
    {
        List<TokenLibrary.TokensClass> token = new List<TokenLibrary.TokensClass>();
        Tokens t = new Tokens();

        foreach (var item in tokens)
        {
            t = new Tokens();
            t.setLexemes(item.getLexemes());
            t.setLines(item.getLines());
            t.setTokens(item.getTokens());
            token.Add(t);
        }

        return token;
    }

    private void clear_Click(object sender, EventArgs e)
    {
        syntax.Enabled = false;
        semantic.Enabled = false;
        LexGrid.Rows.Clear();
        DataLexicalError.Rows.Clear();
        DataSyntaxError.Rows.Clear();
        Code.RichTextBox.Clear();
    }

    private void DataLexicalError_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void semantic_Click(object sender, EventArgs e)
    {
        Dictionary<string, string[]> functionVariables = new Dictionary<string, string[]>();
        List<string> globalConstList = new List<string>();
        List<string> globalVarList = new List<string>();
        List<string> localVarList = new List<string>();
        List<string> localConstList = new List<string>();
        List<string> funcList = new List<string>();
        List<string> reservedWords = new List<string> { "base", "hold", "push", "comp", "for", "spawn", "to", "tower", "void", "buff", "debuff", "commit", "destroy", "do", "else", "if", "while", "recall", "bloat", "inter", "pool", "ping" };
        List<string> operators = new List<string> { "+", "-", "*", "/", "=" };
        List<string> display = new List<string>();

        bool globalCompExist;
        bool globalVarExist;
        bool localVarExist;
        bool localConstExist;
        int idn = 0;
        int line = 1;
        int x = 0;

        semanticError.Rows.Clear();

        int endOfFuntion = 0;

        globalConstList.Clear();
        globalVarList.Clear();
        localVarList.Clear();
        localConstList.Clear();
        functionVariables.Clear();
        funcList.Clear();

        tabControl2.SelectTab("tabPage5");
        for (x = 0; x < LexGrid.Rows.Count; x++)
        {   
            if (LexGrid.Rows[x].Cells[2].Value.ToString() == "newline")
            {
                line++;
                continue;
            }

            // Global Constants
            if (LexGrid.Rows[x].Cells[2].Value.ToString() == "comp")
            {
                x++;

                if (LexGrid.Rows[x].Cells[2].Value.ToString() == "inter")
                {
                    do
                    {
                        if (LexGrid.Rows[x].Cells[2].Value.ToString() == "Identifier")
                        {
                            if (globalCompExist = globalConstList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == true)
                            {
                                semanticError.Rows.Add(idn++, "Multiple Declaration of a Variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), line);
                            }
                            else
                            {
                                globalConstList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                intList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                            }
                        }
                        else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "=" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Inter Literal" || LexGrid.Rows[x].Cells[2].Value.ToString() == ";" || LexGrid.Rows[x].Cells[2].Value.ToString() == "(" || LexGrid.Rows[x].Cells[2].Value.ToString() == ")" || LexGrid.Rows[x].Cells[2].Value.ToString() == "{" || LexGrid.Rows[x].Cells[2].Value.ToString() == "[" || LexGrid.Rows[x].Cells[2].Value.ToString() == "]")
                        {

                        }
                        else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "inter" || LexGrid.Rows[x].Cells[2].Value.ToString() == "," || LexGrid.Rows[x].Cells[2].Value.ToString() == "space")
                        {

                        }
                        else
                        {
                            semanticError.Rows.Add(idn++, "TypeMismatch: " + LexGrid.Rows[x].Cells[2].Value.ToString(), line);
                        }

                        x++;

                    } while ((LexGrid.Rows[x].Cells[2].Value.ToString() != ";") && (LexGrid.Rows[x].Cells[2].Value.ToString() != "{"));
                }

                if (LexGrid.Rows[x].Cells[2].Value.ToString() == "bloat")
                {
                    do
                    {
                        if (LexGrid.Rows[x].Cells[2].Value.ToString() == "Identifier")
                        {
                            if (globalCompExist = globalConstList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == true)
                            {
                                semanticError.Rows.Add(idn++, "Multiple Declaration of a Variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), line);
                            }
                            else
                            {
                                globalConstList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                intList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                            }
                        }
                        else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "=" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Bloat Literal" || LexGrid.Rows[x].Cells[2].Value.ToString() == ";" || LexGrid.Rows[x].Cells[2].Value.ToString() == "(" || LexGrid.Rows[x].Cells[2].Value.ToString() == ")" || LexGrid.Rows[x].Cells[2].Value.ToString() == "{" || LexGrid.Rows[x].Cells[2].Value.ToString() == "[" || LexGrid.Rows[x].Cells[2].Value.ToString() == "]")
                        {

                        }
                        else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "bloat" || LexGrid.Rows[x].Cells[2].Value.ToString() == "," || LexGrid.Rows[x].Cells[2].Value.ToString() == "space")
                        {

                        }
                        else
                        {
                            semanticError.Rows.Add(idn++, "TypeMismatch: " + LexGrid.Rows[x].Cells[2].Value.ToString(), line);
                        }

                        x++;

                    } while ((LexGrid.Rows[x].Cells[2].Value.ToString() != ";") && (LexGrid.Rows[x].Cells[2].Value.ToString() != "{"));
                }

                if (LexGrid.Rows[x].Cells[2].Value.ToString() == "pool")
                {
                    do
                    {
                        if (LexGrid.Rows[x].Cells[2].Value.ToString() == "Identifier")
                        {
                            if (globalCompExist = globalConstList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == true)
                            {
                                semanticError.Rows.Add(idn++, "Multiple Declaration of a Variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), line);
                            }
                            else
                            {
                                globalConstList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                intList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                            }
                        }
                        else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "=" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Pool Literal" || LexGrid.Rows[x].Cells[2].Value.ToString() == ";" || LexGrid.Rows[x].Cells[2].Value.ToString() == "(" || LexGrid.Rows[x].Cells[2].Value.ToString() == ")" || LexGrid.Rows[x].Cells[2].Value.ToString() == "{" || LexGrid.Rows[x].Cells[2].Value.ToString() == "[" || LexGrid.Rows[x].Cells[2].Value.ToString() == "]")
                        {

                        }
                        else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "pool" || LexGrid.Rows[x].Cells[2].Value.ToString() == "," || LexGrid.Rows[x].Cells[2].Value.ToString() == "space")
                        {

                        }
                        else
                        {
                            semanticError.Rows.Add(idn++, "TypeMismatch: " + LexGrid.Rows[x].Cells[2].Value.ToString(), line);
                        }

                        x++;

                    } while ((LexGrid.Rows[x].Cells[2].Value.ToString() != ";") && (LexGrid.Rows[x].Cells[2].Value.ToString() != "{"));
                }

                if (LexGrid.Rows[x].Cells[2].Value.ToString() == "ping")
                {
                    do
                    {
                        if (LexGrid.Rows[x].Cells[2].Value.ToString() == "Identifier")
                        {
                            if (globalCompExist = globalConstList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == true)
                            {
                                semanticError.Rows.Add(idn++, "Multiple Declaration of a Variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), line);
                            }
                            else
                            {
                                globalConstList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                intList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                            }
                        }
                        else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "=" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Ping Literal" || LexGrid.Rows[x].Cells[2].Value.ToString() == ";" || LexGrid.Rows[x].Cells[2].Value.ToString() == "(" || LexGrid.Rows[x].Cells[2].Value.ToString() == ")" || LexGrid.Rows[x].Cells[2].Value.ToString() == "{" || LexGrid.Rows[x].Cells[2].Value.ToString() == "[" || LexGrid.Rows[x].Cells[2].Value.ToString() == "]")
                        {

                        }
                        else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "ping" || LexGrid.Rows[x].Cells[2].Value.ToString() == "," || LexGrid.Rows[x].Cells[2].Value.ToString() == "space")
                        {

                        }
                        else
                        {
                            semanticError.Rows.Add(idn++, "TypeMismatch: " + LexGrid.Rows[x].Cells[2].Value.ToString(), line);
                        }

                        x++;

                    } while ((LexGrid.Rows[x].Cells[2].Value.ToString() != ";") && (LexGrid.Rows[x].Cells[2].Value.ToString() != "{"));
                }
            }

            // Global Variables
            if (LexGrid.Rows[x].Cells[2].Value.ToString() == "inter")
            {
                do
                {
                    if (LexGrid.Rows[x].Cells[2].Value.ToString() == "Identifier")
                    {
                        if (globalVarExist = globalVarList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == true)
                        {
                            semanticError.Rows.Add(idn++, "Multiple Declaration of a Variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), line);
                        }
                        else
                        {
                            globalVarList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                            intList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                        }
                    }
                    else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "=" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Inter Literal" || LexGrid.Rows[x].Cells[2].Value.ToString() == ";" || LexGrid.Rows[x].Cells[2].Value.ToString() == "(" || LexGrid.Rows[x].Cells[2].Value.ToString() == ")" || LexGrid.Rows[x].Cells[2].Value.ToString() == "{" || LexGrid.Rows[x].Cells[2].Value.ToString() == "[" || LexGrid.Rows[x].Cells[2].Value.ToString() == "]")
                    {

                    }
                    else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "inter" || LexGrid.Rows[x].Cells[2].Value.ToString() == "," || LexGrid.Rows[x].Cells[2].Value.ToString() == "space")
                    {

                    }
                    else
                    {
                        semanticError.Rows.Add(idn++, "TypeMismatch: " + LexGrid.Rows[x].Cells[2].Value.ToString(), line);
                    }

                    x++;
                } while ((LexGrid.Rows[x].Cells[2].Value.ToString() != ";") && (LexGrid.Rows[x].Cells[2].Value.ToString() != "{"));
            }

            if (LexGrid.Rows[x].Cells[2].Value.ToString() == "bloat")
            {
                do
                {
                    if (LexGrid.Rows[x].Cells[2].Value.ToString() == "Identifier")
                    {
                        if (globalVarExist = globalVarList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == true)
                        {
                            semanticError.Rows.Add(idn++, "Multiple Declaration of a Variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), line);
                        }
                        else
                        {
                            globalVarList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                            intList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                        }
                    }
                    else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "=" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Bloat Literal" || LexGrid.Rows[x].Cells[2].Value.ToString() == ";" || LexGrid.Rows[x].Cells[2].Value.ToString() == "(" || LexGrid.Rows[x].Cells[2].Value.ToString() == ")" || LexGrid.Rows[x].Cells[2].Value.ToString() == "{" || LexGrid.Rows[x].Cells[2].Value.ToString() == "[" || LexGrid.Rows[x].Cells[2].Value.ToString() == "]")
                    {

                    }
                    else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "bloat" || LexGrid.Rows[x].Cells[2].Value.ToString() == "," || LexGrid.Rows[x].Cells[2].Value.ToString() == "space")
                    {

                    }
                    else
                    {
                        semanticError.Rows.Add(idn++, "TypeMismatch: " + LexGrid.Rows[x].Cells[2].Value.ToString(), line);
                    }

                    x++;
                } while ((LexGrid.Rows[x].Cells[2].Value.ToString() != ";") && (LexGrid.Rows[x].Cells[2].Value.ToString() != "{"));
            }

            if (LexGrid.Rows[x].Cells[2].Value.ToString() == "pool")
            {
                do
                {
                    if (LexGrid.Rows[x].Cells[2].Value.ToString() == "Identifier")
                    {
                        if (globalVarExist = globalVarList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == true)
                        {
                            semanticError.Rows.Add(idn++, "Multiple Declaration of a Variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), line);
                        }
                        else
                        {
                            globalVarList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                            intList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                        }
                    }
                    else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "=" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Pool Literal" || LexGrid.Rows[x].Cells[2].Value.ToString() == ";" || LexGrid.Rows[x].Cells[2].Value.ToString() == "(" || LexGrid.Rows[x].Cells[2].Value.ToString() == ")" || LexGrid.Rows[x].Cells[2].Value.ToString() == "{" || LexGrid.Rows[x].Cells[2].Value.ToString() == "[" || LexGrid.Rows[x].Cells[2].Value.ToString() == "]")
                    {

                    }
                    else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "pool" || LexGrid.Rows[x].Cells[2].Value.ToString() == "," || LexGrid.Rows[x].Cells[2].Value.ToString() == "space")
                    {

                    }
                    else
                    {
                        semanticError.Rows.Add(idn++, "TypeMismatch: " + LexGrid.Rows[x].Cells[2].Value.ToString(), line);
                    }

                    x++;
                } while ((LexGrid.Rows[x].Cells[2].Value.ToString() != ";") && (LexGrid.Rows[x].Cells[2].Value.ToString() != "{"));
            }

            if (LexGrid.Rows[x].Cells[2].Value.ToString() == "ping")
            {
                do
                {
                    if (LexGrid.Rows[x].Cells[2].Value.ToString() == "Identifier")
                    {
                        if (globalVarExist = globalVarList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == true)
                        {
                            semanticError.Rows.Add(idn++, "Multiple Declaration of a Variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), line);
                        }
                        else
                        {
                            globalVarList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                            intList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                        }
                    }
                    else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "=" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Ping Literal" || LexGrid.Rows[x].Cells[2].Value.ToString() == ";" || LexGrid.Rows[x].Cells[2].Value.ToString() == "(" || LexGrid.Rows[x].Cells[2].Value.ToString() == ")" || LexGrid.Rows[x].Cells[2].Value.ToString() == "{" || LexGrid.Rows[x].Cells[2].Value.ToString() == "[" || LexGrid.Rows[x].Cells[2].Value.ToString() == "]")
                    {

                    }
                    else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "ping" || LexGrid.Rows[x].Cells[2].Value.ToString() == "," || LexGrid.Rows[x].Cells[2].Value.ToString() == "space")
                    {

                    }
                    else
                    {
                        semanticError.Rows.Add(idn++, "TypeMismatch: " + LexGrid.Rows[x].Cells[2].Value.ToString(), line);
                    }

                    x++;
                } while ((LexGrid.Rows[x].Cells[2].Value.ToString() != ";") && (LexGrid.Rows[x].Cells[2].Value.ToString() != "{"));
            }

            // Local Declaration
            if (LexGrid.Rows[x].Cells[2].Value.ToString() == "spawn")
            {
                x = x + 2;

                if (LexGrid.Rows[x].Cells[2].Value.ToString() == "void" && LexGrid.Rows[x+2].Cells[2].Value.ToString() == "base")
                {
                    x = x + 2;
                    if(LexGrid.Rows[x].Cells[2].Value.ToString() == "base")
                    {
                        while (LexGrid.Rows[x].Cells[2].Value.ToString() != "{")
                        {
                            x++;
                        }

                        do
                        {
                            if (LexGrid.Rows[x].Cells[2].Value.ToString() == "{")
                            {
                                endOfFuntion++;
                            }
                            else
                            {
                                endOfFuntion--;
                            }

                            if (LexGrid.Rows[x].Cells[2].Value.ToString() == "inter")
                            {
                                do
                                {
                                    if (LexGrid.Rows[x].Cells[2].Value.ToString() == "Identifier")
                                    {
                                        if (localVarExist = localVarList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == true)
                                        {
                                            semanticError.Rows.Add(idn++, "Multiple Declaration of a Variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), line);
                                        }
                                        else
                                        {
                                            localVarList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                            intList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                        }
                                    }
                                    else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "=" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Inter Literal" || LexGrid.Rows[x].Cells[2].Value.ToString() == ";" || LexGrid.Rows[x].Cells[2].Value.ToString() == "(" || LexGrid.Rows[x].Cells[2].Value.ToString() == ")" || LexGrid.Rows[x].Cells[2].Value.ToString() == "{" || LexGrid.Rows[x].Cells[2].Value.ToString() == "[" || LexGrid.Rows[x].Cells[2].Value.ToString() == "]")
                                    {

                                    }
                                    else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "inter" || LexGrid.Rows[x].Cells[2].Value.ToString() == "," || LexGrid.Rows[x].Cells[2].Value.ToString() == "space")
                                    {

                                    }
                                    else
                                    {
                                        semanticError.Rows.Add(idn++, "TypeMismatch: " + LexGrid.Rows[x].Cells[2].Value.ToString(), line);
                                    }

                                    x++;

                                } while ((LexGrid.Rows[x].Cells[2].Value.ToString() != ";") && (LexGrid.Rows[x].Cells[2].Value.ToString() != "{"));
                            }

                            if (LexGrid.Rows[x].Cells[2].Value.ToString() == "bloat")
                            {
                                do
                                {
                                    if (LexGrid.Rows[x].Cells[2].Value.ToString() == "Identifier")
                                    {
                                        if (localVarExist = localVarList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == true)
                                        {
                                            semanticError.Rows.Add(idn++, "Multiple Declaration of a Variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), line);
                                        }
                                        else
                                        {
                                            localVarList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                            intList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                        }
                                    }
                                    else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "=" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Bloat Literal" || LexGrid.Rows[x].Cells[2].Value.ToString() == ";" || LexGrid.Rows[x].Cells[2].Value.ToString() == "(" || LexGrid.Rows[x].Cells[2].Value.ToString() == ")" || LexGrid.Rows[x].Cells[2].Value.ToString() == "{" || LexGrid.Rows[x].Cells[2].Value.ToString() == "[" || LexGrid.Rows[x].Cells[2].Value.ToString() == "]")
                                    {

                                    }
                                    else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "bloat" || LexGrid.Rows[x].Cells[2].Value.ToString() == "," || LexGrid.Rows[x].Cells[2].Value.ToString() == "space")
                                    {

                                    }
                                    else
                                    {
                                        semanticError.Rows.Add(idn++, "TypeMismatch: " + LexGrid.Rows[x].Cells[2].Value.ToString(), line);
                                    }

                                    x++;
                                } while ((LexGrid.Rows[x].Cells[2].Value.ToString() != ";") && (LexGrid.Rows[x].Cells[2].Value.ToString() != "{"));
                            }

                            if (LexGrid.Rows[x].Cells[2].Value.ToString() == "pool")
                            {
                                do
                                {
                                    if (LexGrid.Rows[x].Cells[2].Value.ToString() == "Identifier")
                                    {
                                        if (localVarExist = localVarList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == true)
                                        {
                                            semanticError.Rows.Add(idn++, "Multiple Declaration of a Variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), line);
                                        }
                                        else
                                        {
                                            localVarList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                            intList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                        }
                                    }
                                    else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "=" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Pool Literal" || LexGrid.Rows[x].Cells[2].Value.ToString() == ";" || LexGrid.Rows[x].Cells[2].Value.ToString() == "(" || LexGrid.Rows[x].Cells[2].Value.ToString() == ")" || LexGrid.Rows[x].Cells[2].Value.ToString() == "{" || LexGrid.Rows[x].Cells[2].Value.ToString() == "[" || LexGrid.Rows[x].Cells[2].Value.ToString() == "]")
                                    {

                                    }
                                    else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "pool" || LexGrid.Rows[x].Cells[2].Value.ToString() == "," || LexGrid.Rows[x].Cells[2].Value.ToString() == "space")
                                    {

                                    }
                                    else
                                    {
                                        semanticError.Rows.Add(idn++, "TypeMismatch: " + LexGrid.Rows[x].Cells[2].Value.ToString(), line);
                                    }

                                    x++;
                                } while ((LexGrid.Rows[x].Cells[2].Value.ToString() != ";") && (LexGrid.Rows[x].Cells[2].Value.ToString() != "{"));
                            }

                            if (LexGrid.Rows[x].Cells[2].Value.ToString() == "ping")
                            {
                                do
                                {
                                    if (LexGrid.Rows[x].Cells[2].Value.ToString() == "Identifier")
                                    {
                                        if (localVarExist = localVarList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == true)
                                        {
                                            semanticError.Rows.Add(idn++, "Multiple Declaration of a Variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), line);
                                        }
                                        else
                                        {
                                            localVarList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                            intList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                        }
                                    }
                                    else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "=" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Ping Literal" || LexGrid.Rows[x].Cells[2].Value.ToString() == ";" || LexGrid.Rows[x].Cells[2].Value.ToString() == "(" || LexGrid.Rows[x].Cells[2].Value.ToString() == ")" || LexGrid.Rows[x].Cells[2].Value.ToString() == "{" || LexGrid.Rows[x].Cells[2].Value.ToString() == "[" || LexGrid.Rows[x].Cells[2].Value.ToString() == "]")
                                    {

                                    }
                                    else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "ping" || LexGrid.Rows[x].Cells[2].Value.ToString() == "," || LexGrid.Rows[x].Cells[2].Value.ToString() == "space")
                                    {

                                    }
                                    else
                                    {
                                        semanticError.Rows.Add(idn++, "TypeMismatch: " + LexGrid.Rows[x].Cells[2].Value.ToString(), line);
                                    }

                                    x++;
                                } while ((LexGrid.Rows[x].Cells[2].Value.ToString() != ";") && (LexGrid.Rows[x].Cells[2].Value.ToString() != "{"));
                            }

                            if (LexGrid.Rows[x].Cells[2].Value.ToString() == "comp")
                            {
                                x++;

                                if (LexGrid.Rows[x].Cells[2].Value.ToString() == "inter")
                                {
                                    do
                                    {
                                        if (LexGrid.Rows[x].Cells[2].Value.ToString() == "Identifier")
                                        {
                                            if (localConstExist = localConstList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == true)
                                            {
                                                semanticError.Rows.Add(idn++, "Multiple Declaration of a Variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), line);
                                            }
                                            else
                                            {
                                                localConstList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                                intList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                            }
                                        }
                                        else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "=" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Inter Literal" || LexGrid.Rows[x].Cells[2].Value.ToString() == ";" || LexGrid.Rows[x].Cells[2].Value.ToString() == "(" || LexGrid.Rows[x].Cells[2].Value.ToString() == ")" || LexGrid.Rows[x].Cells[2].Value.ToString() == "{" || LexGrid.Rows[x].Cells[2].Value.ToString() == "[" || LexGrid.Rows[x].Cells[2].Value.ToString() == "]")
                                        {

                                        }
                                        else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "inter" || LexGrid.Rows[x].Cells[2].Value.ToString() == "," || LexGrid.Rows[x].Cells[2].Value.ToString() == "space")
                                        {

                                        }
                                        else
                                        {
                                            semanticError.Rows.Add(idn++, "TypeMismatch: " + LexGrid.Rows[x].Cells[2].Value.ToString(), line);
                                        }

                                        x++;

                                    } while ((LexGrid.Rows[x].Cells[2].Value.ToString() != ";") && (LexGrid.Rows[x].Cells[2].Value.ToString() != "{"));
                                }

                                if (LexGrid.Rows[x].Cells[2].Value.ToString() == "bloat")
                                {
                                    do
                                    {
                                        if (LexGrid.Rows[x].Cells[2].Value.ToString() == "Identifier")
                                        {
                                            if (localConstExist = localConstList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == true)
                                            {
                                                semanticError.Rows.Add(idn++, "Multiple Declaration of a Variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), line);
                                            }
                                            else
                                            {
                                                localConstList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                                intList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                            }
                                        }
                                        else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "=" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Bloat Literal" || LexGrid.Rows[x].Cells[2].Value.ToString() == ";" || LexGrid.Rows[x].Cells[2].Value.ToString() == "(" || LexGrid.Rows[x].Cells[2].Value.ToString() == ")" || LexGrid.Rows[x].Cells[2].Value.ToString() == "{" || LexGrid.Rows[x].Cells[2].Value.ToString() == "[" || LexGrid.Rows[x].Cells[2].Value.ToString() == "]")
                                        {

                                        }
                                        else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "bloat" || LexGrid.Rows[x].Cells[2].Value.ToString() == "," || LexGrid.Rows[x].Cells[2].Value.ToString() == "space")
                                        {

                                        }
                                        else
                                        {
                                            semanticError.Rows.Add(idn++, "TypeMismatch: " + LexGrid.Rows[x].Cells[2].Value.ToString(), line);
                                        }

                                        x++;

                                    } while ((LexGrid.Rows[x].Cells[2].Value.ToString() != ";") && (LexGrid.Rows[x].Cells[2].Value.ToString() != "{"));
                                }

                                if (LexGrid.Rows[x].Cells[2].Value.ToString() == "pool")
                                {
                                    do
                                    {
                                        if (LexGrid.Rows[x].Cells[2].Value.ToString() == "Identifier")
                                        {
                                            if (localConstExist = localConstList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == true)
                                            {
                                                semanticError.Rows.Add(idn++, "Multiple Declaration of a Variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), line);
                                            }
                                            else
                                            {
                                                localConstList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                                intList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                            }
                                        }
                                        else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "=" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Pool Literal" || LexGrid.Rows[x].Cells[2].Value.ToString() == ";" || LexGrid.Rows[x].Cells[2].Value.ToString() == "(" || LexGrid.Rows[x].Cells[2].Value.ToString() == ")" || LexGrid.Rows[x].Cells[2].Value.ToString() == "{" || LexGrid.Rows[x].Cells[2].Value.ToString() == "[" || LexGrid.Rows[x].Cells[2].Value.ToString() == "]")
                                        {

                                        }
                                        else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "pool" || LexGrid.Rows[x].Cells[2].Value.ToString() == "," || LexGrid.Rows[x].Cells[2].Value.ToString() == "space")
                                        {

                                        }
                                        else
                                        {
                                            semanticError.Rows.Add(idn++, "TypeMismatch: " + LexGrid.Rows[x].Cells[2].Value.ToString(), line);
                                        }

                                        x++;

                                    } while ((LexGrid.Rows[x].Cells[2].Value.ToString() != ";") && (LexGrid.Rows[x].Cells[2].Value.ToString() != "{"));
                                }

                                if (LexGrid.Rows[x].Cells[2].Value.ToString() == "ping")
                                {
                                    do
                                    {
                                        if (LexGrid.Rows[x].Cells[2].Value.ToString() == "Identifier")
                                        {
                                            if (localConstExist = localConstList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == true)
                                            {
                                                semanticError.Rows.Add(idn++, "Multiple Declaration of a Variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), line);
                                            }
                                            else
                                            {
                                                localConstList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                                intList.Add(LexGrid.Rows[x].Cells[1].Value.ToString());
                                            }
                                        }
                                        else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "=" || LexGrid.Rows[x].Cells[2].Value.ToString() == "Ping Literal" || LexGrid.Rows[x].Cells[2].Value.ToString() == ";" || LexGrid.Rows[x].Cells[2].Value.ToString() == "(" || LexGrid.Rows[x].Cells[2].Value.ToString() == ")" || LexGrid.Rows[x].Cells[2].Value.ToString() == "{" || LexGrid.Rows[x].Cells[2].Value.ToString() == "[" || LexGrid.Rows[x].Cells[2].Value.ToString() == "]")
                                        {

                                        }
                                        else if (LexGrid.Rows[x].Cells[2].Value.ToString() == "ping" || LexGrid.Rows[x].Cells[2].Value.ToString() == "," || LexGrid.Rows[x].Cells[2].Value.ToString() == "space")
                                        {

                                        }
                                        else
                                        {
                                            semanticError.Rows.Add(idn++, "TypeMismatch: " + LexGrid.Rows[x].Cells[2].Value.ToString(), line);
                                        }

                                        x++;

                                    } while ((LexGrid.Rows[x].Cells[2].Value.ToString() != ";") && (LexGrid.Rows[x].Cells[2].Value.ToString() != "{"));
                                }
                            }
                        } while (endOfFuntion == 0);
                    }
                    else
                    {

                    }
                }
                else
                {
                    if (LexGrid.Rows[x].Cells[2].Value.ToString() == "Identifier")
                    {
            
                    }
                }
            }

            
            // Checking if it exists
            foreach (string conslist in globalConstList)
            {
                if (globalVarList.Contains(conslist))
                {
                    semanticError.Rows.Add(idn++, "Multiple Declaration of a Variable: " + conslist, line);
                }
                if (localVarList.Contains(conslist))
                {
                    semanticError.Rows.Add(idn++, "Multiple Declaration of a Variable: " + conslist, line);
                }
                if (localConstList.Contains(conslist))
                {
                    semanticError.Rows.Add(idn++, "Multiple Declaration of a Variable: " + conslist, line);
                }
                if (reservedWords.Contains(conslist))
                {
                    semanticError.Rows.Add(idn++, "Reserved Identifier Misused: " + conslist, line);
                }
                else
                {
                    continue;
                }
            }

            foreach (string varlist in globalVarList)
            {
                if (globalConstList.Contains(varlist))
                {
                    semanticError.Rows.Add(idn++, "Multiple Declaration of a Variable: " + varlist, line);
                }
                if (localVarList.Contains(varlist))
                {
                    semanticError.Rows.Add(idn++, "Multiple Declaration of a Variable: " + varlist, line);
                }
                if (localConstList.Contains(varlist))
                {
                    semanticError.Rows.Add(idn++, "Multiple Declaration of a Variable: " + varlist, line);
                }
                if (reservedWords.Contains(varlist))
                {
                    semanticError.Rows.Add(idn++, "Reserved Identifier Misused: " + varlist, line);
                }
                else
                {
                    continue;
                }
            }

            foreach (string loclist in localVarList)
            {
                if (globalConstList.Contains(loclist))
                {
                    semanticError.Rows.Add(idn++, "Multiple Declaration of a Variable: " + loclist, line);
                }
                if (globalVarList.Contains(loclist))
                {
                    semanticError.Rows.Add(idn++, "Multiple Declaration of a Variable: " + loclist, line);
                }
                if (localConstList.Contains(loclist))
                {
                    semanticError.Rows.Add(idn++, "Multiple Declaration of a Variable: " + loclist, line);
                }
                if (reservedWords.Contains(loclist))
                {
                    semanticError.Rows.Add(idn++, "Reserved Identifier Misused: " + loclist, line);
                }
                else
                {
                    continue;
                }
            }

            foreach (string locList in localConstList)
            {
                if (globalConstList.Contains(locList))
                {
                    semanticError.Rows.Add(idn++, "Multiple Declaration of a Variable: " + locList, line);
                }
                if (globalVarList.Contains(locList))
                {
                    semanticError.Rows.Add(idn++, "Multiple Declaration of a Variable: " + locList, line);
                }
                if (localVarList.Contains(locList))
                {
                    semanticError.Rows.Add(idn++, "Multiple Declaration of a Variable: " + locList, line);
                }
                if (reservedWords.Contains(locList))
                {
                    semanticError.Rows.Add(idn++, "Reserved Identifier Misused: " + locList, line);
                }
                else
                {
                    continue;
                }
            }
        }

        x = 0;
        line = 1;

        // check for variable usages
        for (x = 0; x < LexGrid.Rows.Count; x++)
        {
            if (LexGrid.Rows[x].Cells[2].Value.ToString() == "newline")
            {
                line++;
            }
            
            if (LexGrid.Rows[x].Cells[2].Value.ToString() == "id")
            {
                bool exist;
                if (exist = globalConstList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == false) {
                    semanticError.Rows.Add(idn++, "Accessing undeclared Variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), line);
                }
                else if (exist = globalVarList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == false){
                    semanticError.Rows.Add(idn++, "Accessing undeclared Variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), line);
                }
                else if (exist = localVarList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == false){
                    semanticError.Rows.Add(idn++, "Accessing undeclared Variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), line);
                }
                else if (exist = funcList.Exists(element => element == LexGrid.Rows[x].Cells[1].Value.ToString()) == false)
                {
                    semanticError.Rows.Add(idn++, "Accessing undeclared Variable: " + LexGrid.Rows[x].Cells[1].Value.ToString(), line);
                }
            }
            else
            {

            }
        }
    }

    private void semanticError_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }
}