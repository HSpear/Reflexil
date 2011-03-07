/* Reflexil Copyright (c) 2007-2010 Sebastien LEBRETON

Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. */

#region " Imports "
using System.Windows.Forms;
using Mono.Cecil;
using Mono.Cecil.Cil;
#endregion

namespace Reflexil.Forms
{
    public partial class VariableForm : Reflexil.Forms.TypeSpecificationForm
    {

        #region " Fields "
        private MethodDefinition m_mdef;
        private VariableDefinition m_selectedvariable;
        #endregion

        #region " Properties "
        public MethodDefinition MethodDefinition
        {
            get
            {
                return m_mdef;
            }
        }

        public VariableDefinition SelectedVariable
        {
            get
            {
                return m_selectedvariable;
            }
        }
        #endregion

        #region " Methods "
        public VariableForm()
        {
            InitializeComponent();
        }

        protected VariableDefinition CreateVariable()
        {
            VariableDefinition result = new VariableDefinition(MethodDefinition.DeclaringType.Module.Import(TypeSpecificationEditor.SelectedTypeReference));
            result.Name = ItemName.Text;
            return result;
        }

        public virtual DialogResult ShowDialog(MethodDefinition mdef, VariableDefinition selected)
        {
            m_mdef = mdef;
            m_selectedvariable = selected;
            return base.ShowDialog(mdef);
        }
        #endregion

    }
}
