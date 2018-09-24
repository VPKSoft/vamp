#region License
/*
vamp#

A software for video audio and photo playback.
Copyright © 2018 VPKSoft, Petteri Kautonen

Contact: vpksoft@vpksoft.net

This file is part of vamp#.

vamp# is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

vamp# is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with vamp#.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

using System.Windows.Forms;

namespace vamp
{
    /// <summary>
    /// A base class for a dialog with the correct "color" theme for this application.
    /// </summary>
    public partial class FormDialogBase : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormDialogBase"/> class.
        /// </summary>
        public FormDialogBase()
        {
            InitializeComponent();
        }
    }
}
