﻿using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnforgottenRealms.Editor.Forms
{
    public partial class Main : Form, Drawable
    {
        public Main()
        {
            InitializeComponent();
        }

        public RenderWindow InitializeSfml()
        {
            return drawingSurface.InitializeSfml();
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            
        }
    }
}
