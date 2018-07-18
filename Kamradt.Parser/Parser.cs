using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamradt.Parser.Delimiters;
using Kamradt.Parser.Trees;
using Kamradt.Parser.Functions;
using Kamradt.Parser.Variables;
using System.Web.UI.WebControls;
using System.Web.UI;
using Kamradt.Parser.Exceptions;

namespace Kamradt.Parser
{
    public abstract class Parser<t1, t2, t3>
        where t1 : IVariableCollection<t2>
        where t2 : IVariableCollectionKey
        where t3 : IRequiredVariables<t1, t2>
    {
        public ILeaf<t1, t2, t3> RootLeaf { get; private set; }
        public string Formula { get; protected set; }
        public List<t2> RequiredVariables { get; protected set; }
        private Func<string, t2> GenerateKey { get; set; }
        public event EventHandler<FormulaExceptionEventArgs<t1, t2, t3>> OnSolveError;


        public Parser(string Formula, Func<string, t2> GenerateKey)
            : this(Formula, new Dictionary<string, Func<string, List<ILeaf<t1, t2, t3>>, FunctionLeaf<t1, t2, t3>>>(), GenerateKey)
        {
        }

        public Parser(string Formula, Dictionary<string, Func<string, List<ILeaf<t1, t2, t3>>, FunctionLeaf<t1, t2, t3>>> FunctionLeaves, Func<string, t2> GenerateKey)
        {
            this.GenerateKey = GenerateKey;
            this.Formula = Formula;
            FunctionLeaves.ToList().ForEach(kvp => this.FunctionLeaves.Add(kvp.Key, kvp.Value));
            RootLeaf = Parse(Formula);
            this.RequiredVariables = RootLeaf.RequiredVariables.Distinct().ToList();
        }

        private Dictionary<string, Func<string, List<ILeaf<t1, t2, t3>>, FunctionLeaf<t1, t2, t3>>> _FunctionLeaves;
        protected Dictionary<string, Func<string, List<ILeaf<t1, t2, t3>>, FunctionLeaf<t1, t2, t3>>> FunctionLeaves
        {
            get
            {
                if (this._FunctionLeaves == null)
                {
                    this._FunctionLeaves = new Dictionary<string, Func<string, List<ILeaf<t1, t2, t3>>, FunctionLeaf<t1, t2, t3>>>();

                    this._FunctionLeaves.Add("if", (f, l) => new If<t1, t2, t3>(f, l));
                    this._FunctionLeaves.Add("in", (f, l) => new In<t1, t2, t3>(f, l));
                    this._FunctionLeaves.Add("len", (f, l) => new Len<t1, t2, t3>(f, l));
                    this._FunctionLeaves.Add("substring", (f, l) => new Substring<t1, t2, t3>(f, l));
                    this._FunctionLeaves.Add("ifnull", (f, l) => new IfNull<t1, t2, t3>(f, l));
                }

                return this._FunctionLeaves;
            }
        }

        private List<Dictionary<string, Type>> _DelimiterLeaves;
        protected List<Dictionary<string, Type>> DelimiterLeaves
        {
            get
            {
                if (this._DelimiterLeaves == null)
                {
                    this._DelimiterLeaves = new List<Dictionary<string, Type>>(new Dictionary<string, Type>[]
                    {
                        new Dictionary<string, Type>()
                        {
                            { "&&", typeof(And<t1, t2, t3>) },
                            { "||", typeof(Or<t1, t2, t3>) }
                        },
                        new Dictionary<string, Type>()
                        {
                            { "==", typeof(Equals<t1, t2, t3>) },
                            { "!=", typeof(NotEqual<t1, t2, t3>) },
                            { ">=", typeof(GreaterThanOrEqual<t1, t2, t3>) },
                            { "<=", typeof(LessThanOrEqual<t1, t2, t3>) },
                            { ">", typeof(GreaterThan<t1, t2, t3>) },
                            { "<", typeof(LessThan<t1, t2, t3>) }
                        },
                        new Dictionary<string, Type>()
                        {
                            { "+", typeof(Plus<t1, t2, t3>) },
                            { "-", typeof(Minus<t1, t2, t3>) }
                        },
                        new Dictionary<string, Type>()
                        {
                            { "/", typeof(Divide<t1, t2, t3>) },
                            { "*", typeof(Multiply<t1, t2, t3>) }
                        },
                        new Dictionary<string, Type>()
                        {
                            { "^", typeof(Power<t1, t2, t3>) }
                        }
                    });
                }

                return this._DelimiterLeaves;
            }
        }

        public IComparable Solve(t1 Variables)
        {
            IComparable result = null;

            try
            {
                result = RootLeaf.Solve(Variables);
            }
            catch (Exception ex)
            {
                this.OnSolveError(this, new FormulaExceptionEventArgs<t1, t2, t3>(this, Variables, ex));
                throw ex;
            }

            return result;
        }

        public t4 Solve<t4>(t1 Variables)
        {
            IComparable val = this.Solve(Variables);

            if (val == null)
                return default(t4);

            return (t4)Convert.ChangeType(val, typeof(t4));
        }

        private ILeaf<t1, t2, t3> Parse(string Formula)
        {
            Formula = Formula.Trim();
            string left = String.Empty, right = String.Empty;

            ILeaf<t1, t2, t3> delimiterLeaf = this.ParseDelimiters(Formula);

            if (delimiterLeaf != null)
                return delimiterLeaf;

            ILeaf<t1, t2, t3> functionLeaf = this.ParseFunctions(Formula);

            if (functionLeaf != null)
                return functionLeaf;

            if (Formula.StartsWith("(") && Formula.EndsWith(")"))
                return Parse(Formula.Substring(1, Formula.Length - 2));

            return new EndLeaf<t1, t2, t3>(Formula, this.GenerateKey);
        }

        private ILeaf<t1, t2, t3> ParseFunctions(string Formula)
        {
            foreach (KeyValuePair<string, Func<string, List<ILeaf<t1, t2, t3>>, FunctionLeaf<t1, t2, t3>>> func in FunctionLeaves)
            {
                if (Formula.StartsWith(String.Format("{0}(", func.Key)) && Formula.EndsWith(")"))
                {
                    List<string> leaves = Formula.Substring(func.Key.Length + 1, Formula.Length - func.Key.Length - 2).Split(',').ToList();

                    int index = leaves.FindIndex(s => !s.CharCountMatches('(', ')'));
                    while (index != -1)
                    {
                        leaves.Insert(index, leaves[index] + "," + leaves[index + 1]);
                        leaves.RemoveRange(index + 1, 2);
                        index = leaves.FindIndex(s => !s.CharCountMatches('(', ')'));
                    }

                    return func.Value(Formula, leaves.ConvertAll<ILeaf<t1, t2, t3>>(l => Parse(l)));
                }
            }
            
            return null;
        }

        private ILeaf<t1, t2, t3> ParseDelimiters(string Formula)
        {
            foreach (Dictionary<string, Type> delims in this.DelimiterLeaves)
            {
                IEnumerable<DelimResult> matches = Formula.IndexesWhere(delims, (d) => Formula.Substring(d.Index).StartsWith(d.Delimiter.Key) && d.LHS.CharacterCount('\'') % 2 == 0 && d.RHS.CharacterCount('\'') % 2 == 0 && d.LHS.CharCountMatches('(', ')') && d.RHS.CharCountMatches('(', ')'), (d1, d2) => d1.Delimiter.Key.Length > d2.Delimiter.Key.Length ? d1 : d2).DefaultIfEmpty(null);
                DelimResult match = matches.DefaultIfEmpty(null).LastOrDefault(d => 
                    d != null 
                    && d.LHS.CharCountMatches('(', ')') 
                    && d.RHS.CharCountMatches('(', ')') 
                    && d.LHS.CharacterCount('\'') % 2 == 0 
                    && d.RHS.CharacterCount('\'') % 2 == 0
                    && !this.DelimiterLeaves.SelectMany(d2 => d2.Select(d3 => d3.Key)).Any(d4 => d.LHS.EndsWith(d4)));

                if (match != null)
                {
                    if (match.Delimiter.Key.Equals("-") && String.IsNullOrEmpty(match.LHS))
                        return null;

                    return (BranchingLeaf<t1, t2, t3>)Activator.CreateInstance(match.Delimiter.Value, Formula, Parse(match.LHS), Parse(match.RHS));
                }
            }
            return null;
        }
    }
}