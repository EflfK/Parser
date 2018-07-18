<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormulaTreeTest.aspx.cs" Inherits="Kamradt.Parser.Web.Test.FormulaTreeTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <fp:StandardTreeFormula runat="server" ID="TestStandardTree" StartingField="a">
        <HeaderTemplate>
            <table>
        </HeaderTemplate>
        <FormulaTemplate>
            <tr>
                <td>
                    <%#Eval("Field") %>
                </td>
                <td>
                    =
                </td>
                <td>
                    <fp:StandardFormattedFormula runat="server" ID="StandardFormula" DataBindFormulaPath="TreeLeaf.Formula"><VariableTemplate>
                    <a href="http://www.google.com?test=<%# Eval("VariableName") %>"><%#Eval("VariableName") %></a>
                </VariableTemplate>
                <AndTemplate>
                    <fp:StandardFormattedFormula runat="server" ID="AndCondition1" DataBindFormulaPath="LHS.Formula"></fp:StandardFormattedFormula>
                    and
                    <fp:StandardFormattedFormula runat="server" ID="AndCondition2" DataBindFormulaPath="RHS.Formula"></fp:StandardFormattedFormula>
                </AndTemplate>
                <DivideTemplate>
                    <table>
                        <tr>
                            <td style="text-align:center">
                                <fp:StandardFormattedFormula runat="server" ID="Numerator" DataBindFormulaPath="LHS.Formula"></fp:StandardFormattedFormula>
                            </td>
                        </tr>
                        <tr>
                            <td style="border-top:solid 1px black;text-align:center">
                                <fp:StandardFormattedFormula runat="server" ID="Denominator" DataBindFormulaPath="RHS.Formula"></fp:StandardFormattedFormula>
                            </td>
                        </tr>
                    </table>
                </DivideTemplate>
                <EqualsTemplate>
                    <fp:StandardFormattedFormula runat="server" ID="LHSEquals" DataBindFormulaPath="LHS.Formula"></fp:StandardFormattedFormula>
                    is equal to
                    <fp:StandardFormattedFormula runat="server" ID="RHSEquals" DataBindFormulaPath="RHS.Formula"></fp:StandardFormattedFormula>
                </EqualsTemplate>
                <GreaterThanTemplate>
                    <fp:StandardFormattedFormula runat="server" ID="LHSGreaterThan" DataBindFormulaPath="LHS.Formula"></fp:StandardFormattedFormula>
                    is greater than
                    <fp:StandardFormattedFormula runat="server" ID="RHSGreaterThan" DataBindFormulaPath="RHS.Formula"></fp:StandardFormattedFormula>
                </GreaterThanTemplate>
                <GreaterThanOrEqualTemplate>
                    <fp:StandardFormattedFormula runat="server" ID="LHSGreaterThanOrEqual" DataBindFormulaPath="LHS.Formula"></fp:StandardFormattedFormula>
                    is greater than or equal to
                    <fp:StandardFormattedFormula runat="server" ID="RHSGreaterThanOrEqual" DataBindFormulaPath="RHS.Formula"></fp:StandardFormattedFormula></GreaterThanOrEqualTemplate>
                <LessThanTemplate>
                    <fp:StandardFormattedFormula runat="server" ID="LHSLessThan" DataBindFormulaPath="LHS.Formula"></fp:StandardFormattedFormula>
                    is less than
                    <fp:StandardFormattedFormula runat="server" ID="RHSLessThan" DataBindFormulaPath="RHS.Formula"></fp:StandardFormattedFormula></LessThanTemplate>
                <LessThanOrEqualTemplate>
                    <fp:StandardFormattedFormula runat="server" ID="LHSLessThanOrEqual" DataBindFormulaPath="LHS.Formula"></fp:StandardFormattedFormula>
                    is less than or equal to
                    <fp:StandardFormattedFormula runat="server" ID="RHSLessThanOrEqual" DataBindFormulaPath="RHS.Formula"></fp:StandardFormattedFormula></LessThanTemplate></LessThanOrEqualTemplate>
                <MinusTemplate>
                    <fp:StandardFormattedFormula runat="server" ID="LHSMinus" DataBindFormulaPath="LHS.Formula"></fp:StandardFormattedFormula>
                    -
                    <fp:StandardFormattedFormula runat="server" ID="RHSMinus" DataBindFormulaPath="RHS.Formula"></fp:StandardFormattedFormula></LessThanTemplate></MinusTemplate>
                <MultiplyTemplate>
                    <fp:StandardFormattedFormula runat="server" ID="LHSMultiply" DataBindFormulaPath="LHS.Formula"></fp:StandardFormattedFormula>
                    x
                    <fp:StandardFormattedFormula runat="server" ID="RHSMultiply" DataBindFormulaPath="RHS.Formula"></fp:StandardFormattedFormula></LessThanTemplate></MultiplyTemplate>
                <NotEqualTemplate>
                    <fp:StandardFormattedFormula runat="server" ID="LHSNotEqual" DataBindFormulaPath="LHS.Formula"></fp:StandardFormattedFormula>
                    not equal to
                    <fp:StandardFormattedFormula runat="server" ID="RHSNotEqual" DataBindFormulaPath="RHS.Formula"></fp:StandardFormattedFormula></NotEqualTemplate>
                <OrTemplate>
                    <fp:StandardFormattedFormula runat="server" ID="LHSOr" DataBindFormulaPath="LHS.Formula"></fp:StandardFormattedFormula>
                    or
                    <fp:StandardFormattedFormula runat="server" ID="RHSOr" DataBindFormulaPath="RHS.Formula"></fp:StandardFormattedFormula></OrTemplate>
                <PlusTemplate>
                    <fp:StandardFormattedFormula runat="server" ID="LHSPlus" DataBindFormulaPath="LHS.Formula"></fp:StandardFormattedFormula>
                    +
                    <fp:StandardFormattedFormula runat="server" ID="RHSPlus" DataBindFormulaPath="RHS.Formula"></fp:StandardFormattedFormula>
                </PlusTemplate>
                <PowerTemplate>
                    <fp:StandardFormattedFormula runat="server" ID="LHSPower" DataBindFormulaPath="LHS.Formula"></fp:StandardFormattedFormula>
                    ^
                    <fp:StandardFormattedFormula runat="server" ID="RHSPower" DataBindFormulaPath="RHS.Formula"></fp:StandardFormattedFormula>
                </PowerTemplate>
                <IfTemplate>
                    [if <fp:StandardFormattedFormula runat="server" ID="IfCondition" DataBindFormulaPath="Leaves[0].Formula"></fp:StandardFormattedFormula>
                    is true then use <fp:StandardFormattedFormula runat="server" ID="IfTrue" DataBindFormulaPath="Leaves[1].Formula"></fp:StandardFormattedFormula>
                    otherwise use <fp:StandardFormattedFormula runat="server" ID="IfFalse" DataBindFormulaPath="Leaves[2].Formula"></fp:StandardFormattedFormula>]
                </IfTemplate>
                <IfNullTemplate>
                    [if <fp:StandardFormattedFormula runat="server" ID="IfNullCheck" DataBindFormulaPath="Leaves[0].Formula"></fp:StandardFormattedFormula>
                    is null then use <fp:StandardFormattedFormula runat="server" ID="IfNullValue" DataBindFormulaPath="Leaves[1].Formula"></fp:StandardFormattedFormula>]
                </IfNullTemplate>
                <InTemplate>
                    [<%#Eval("Formula") %>]
                </InTemplate>
                <LenTemplate>
                    [length of <fp:StandardFormattedFormula runat="server" ID="LenValue" DataBindFormulaPath="Leaves[0].Formula"></fp:StandardFormattedFormula>]
                </LenTemplate>
                <SubstringTemplate>
                    [portion of <fp:StandardFormattedFormula runat="server" ID="SubstringValue" DataBindFormulaPath="Leaves[0].Formula"></fp:StandardFormattedFormula>
                    starting at <fp:StandardFormattedFormula runat="server" ID="SubstringStartIndex" DataBindFormulaPath="Leaves[1].Formula"></fp:StandardFormattedFormula>
                    using <fp:StandardFormattedFormula runat="server" ID="SubstringLength" DataBindFormulaPath="Leaves[2].Formula"></fp:StandardFormattedFormula>
                    characters]
                </SubstringTemplate></fp:StandardFormattedFormula>
                </td>
            </tr>
        </FormulaTemplate>
        <SubFormulaTemplate>
            <tr>
                <td></td>
                <td></td>
                <td>
                    <fp:StandardTreeFormula runat="server" ID="StandardTree" StartingField='<%#Eval("Field") %>'></fp:StandardTreeFormula>
                </td>
            </tr>
        </SubFormulaTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </fp:StandardTreeFormula>
    </div>
    </form>
</body>
</html>
