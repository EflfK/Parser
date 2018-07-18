<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormulaEntryTest.aspx.cs" Inherits="Kamradt.Parser.Web.Test.FormulaEntryTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function GetFirstValueControl(c) {
            for (i = 0; i < c.childNodes.length; i++) {
                if (c.childNodes[i] != null && c.childNodes[i].getValue != null)
                    return c.childNodes[i];
            }
        }
        function GetDropDownValue(d) {
            for (i = 0; i < c.childNodes.length; i++) {
                if (c.childNodes[i] != null && c.childNodes[i].getValue != null)
                    return c.childNodes[i];
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <fp:FormulaEntry runat="server" ID="FormulaEntry">
            <Nodes>
                <fp:FormulaEntryNode Name="if">
                    <EntryTempalte>
                        <table>
                            <tr>
                                <td>
                                    Condition
                                </td>
                                <td>
                                    <input type="text" id="" />
                                </td>
                            </tr>
                        </table>
                    </EntryTempalte>
                </fp:FormulaEntryNode>
            </Nodes>
        </fp:FormulaEntry>

    </form>
</body>
</html>
