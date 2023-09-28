using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_switch_rows_columns_Form1:Form
  { 


        public howto_switch_rows_columns_Form1()
        {
            InitializeComponent();
        }

        // The data (from http://www.pangloss.com/seidel/shake_rule.html).
        private string all =
@"artless             base-court          apple-john
bawdy               bat-fowling         baggage
beslubbering        beef-witted         barnacle
bootless            beetle-headed       bladder
churlish            boil-brained        boar-pig
cockered            clapper-clawed      bugbear
clouted             clay-brained        bum-bailey
craven              common-kissing      canker-blossom
currish             crook-pated         clack-dish
dankish             dismal-dreaming     clotpole
dissembling         dizzy-eyed          coxcomb
droning             doghearted          codpiece
errant              dread-bolted        death-token
fawning             earth-vexing        dewberry
fobbing             elf-skinned         flap-dragon
froward             fat-kidneyed        flax-wench
frothy              fen-sucked          flirt-gill
gleeking            flap-mouthed        foot-licker
goatish             fly-bitten          fustilarian
gorbellied          folly-fallen        giglet
impertinent         fool-born           gudgeon
infectious          full-gorged         haggard
jarring             guts-griping        harpy
loggerheaded        half-faced          hedge-pig
lumpish             hasty-witted        horn-beast
mammering           hedge-born          hugger-mugger
mangled             hell-hated          joithead
mewling             idle-headed         lewdster
paunchy             ill-breeding        lout
pribbling           ill-nurtured        maggot-pie
puking              knotty-pated        malt-worm
puny                milk-livered        mammet
qualling            motley-minded       measle
rank                onion-eyed          minnow
reeky               plume-plucked       miscreant
roguish             pottle-deep         moldwarp
ruttish             pox-marked          mumble-news
saucy               reeling-ripe        nut-hook
spleeny             rough-hewn          pigeon-egg
spongy              rude-growing        pignut
surly               rump-fed            puttock
tottering           shard-borne         pumpion
unmuzzled           sheep-biting        ratsbane
vain                spur-galled         scut
venomed             swag-bellied        skainsmate
villainous          tardy-gaited        strumpet
warped              tickle-brained      varlot
wayward             toad-spotted        vassal
weedy               unchin-snouted      whey-face
yeasty              weather-bitten      wagtail";

        // Switch rows and columns.
        private void btnSwitch_Click(object sender, EventArgs e)
        {
            // Split the data into lines.
            string[] newline = { "\r\n" };
            string[] lines = all.Split(newline,
                StringSplitOptions.RemoveEmptyEntries);

            // Split the lines into words.
            int num_rows = lines.Length;
            int num_cols = 3;
            string[,] words = new string[num_rows, num_cols];
            for (int row = 0; row < num_rows; row++)
            {
                string[] space = { " " };
                string[] line_words = lines[row].Split(space,
                    StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < num_cols; col++)
                {
                    words[row, col] = line_words[col];
                }
            }

            // Generate the output.
            string result = "";
            for (int col = 0; col < num_cols; col++)
            {
                result += "        private string[] Column" +
                    col.ToString() + " =\r\n";
                result += "        {\r\n";
                for (int row = 0; row < num_rows; row++)
                {
                    result += "            \"" + words[row, col] + "\",\r\n";
                }
                result += "        };\r\n\r\n";
            }

            // Display the result.
            txtResult.Text = result;
        }
    

/// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSwitch = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSwitch
            // 
            this.btnSwitch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSwitch.Location = new System.Drawing.Point(130, 12);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(75, 23);
            this.btnSwitch.TabIndex = 0;
            this.btnSwitch.Text = "Switch";
            this.btnSwitch.UseVisualStyleBackColor = true;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(12, 41);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(310, 208);
            this.txtResult.TabIndex = 1;
            // 
            // howto_switch_rows_columns_Form1
            // 
            this.AcceptButton = this.btnSwitch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 261);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnSwitch);
            this.Name = "howto_switch_rows_columns_Form1";
            this.Text = "howto_switch_rows_columns";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSwitch;
        private System.Windows.Forms.TextBox txtResult;
    }
}

