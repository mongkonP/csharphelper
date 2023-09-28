using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

 

using howto_shakespeare_insulter;
namespace csharphelper_WinApp.Forms_Cs 
    {
     public partial class howto_shakespeare_insulter_Form1:Form
  { 


        public howto_shakespeare_insulter_Form1()
        {
            InitializeComponent();
        }

        // The insult pieces (from http://www.pangloss.com/seidel/shake_rule.html).
        private string[] Column0 =
        {
            "artless",
            "bawdy",
            "beslubbering",
            "bootless",
            "churlish",
            "cockered",
            "clouted",
            "craven",
            "currish",
            "dankish",
            "dissembling",
            "droning",
            "errant",
            "fawning",
            "fobbing",
            "froward",
            "frothy",
            "gleeking",
            "goatish",
            "gorbellied",
            "impertinent",
            "infectious",
            "jarring",
            "loggerheaded",
            "lumpish",
            "mammering",
            "mangled",
            "mewling",
            "paunchy",
            "pribbling",
            "puking",
            "puny",
            "qualling",
            "rank",
            "reeky",
            "roguish",
            "ruttish",
            "saucy",
            "spleeny",
            "spongy",
            "surly",
            "tottering",
            "unmuzzled",
            "vain",
            "venomed",
            "villainous",
            "warped",
            "wayward",
            "weedy",
            "yeasty",
        };

        private string[] Column1 =
        {
            "base-court",
            "bat-fowling",
            "beef-witted",
            "beetle-headed",
            "boil-brained",
            "clapper-clawed",
            "clay-brained",
            "common-kissing",
            "crook-pated",
            "dismal-dreaming",
            "dizzy-eyed",
            "doghearted",
            "dread-bolted",
            "earth-vexing",
            "elf-skinned",
            "fat-kidneyed",
            "fen-sucked",
            "flap-mouthed",
            "fly-bitten",
            "folly-fallen",
            "fool-born",
            "full-gorged",
            "guts-griping",
            "half-faced",
            "hasty-witted",
            "hedge-born",
            "hell-hated",
            "idle-headed",
            "ill-breeding",
            "ill-nurtured",
            "knotty-pated",
            "milk-livered",
            "motley-minded",
            "onion-eyed",
            "plume-plucked",
            "pottle-deep",
            "pox-marked",
            "reeling-ripe",
            "rough-hewn",
            "rude-growing",
            "rump-fed",
            "shard-borne",
            "sheep-biting",
            "spur-galled",
            "swag-bellied",
            "tardy-gaited",
            "tickle-brained",
            "toad-spotted",
            "unchin-snouted",
            "weather-bitten",
        };

        private string[] Column2 =
        {
            "apple-john",
            "baggage",
            "barnacle",
            "bladder",
            "boar-pig",
            "bugbear",
            "bum-bailey",
            "canker-blossom",
            "clack-dish",
            "clotpole",
            "coxcomb",
            "codpiece",
            "death-token",
            "dewberry",
            "flap-dragon",
            "flax-wench",
            "flirt-gill",
            "foot-licker",
            "fustilarian",
            "giglet",
            "gudgeon",
            "haggard",
            "harpy",
            "hedge-pig",
            "horn-beast",
            "hugger-mugger",
            "joithead",
            "lewdster",
            "lout",
            "maggot-pie",
            "malt-worm",
            "mammet",
            "measle",
            "minnow",
            "miscreant",
            "moldwarp",
            "mumble-news",
            "nut-hook",
            "pigeon-egg",
            "pignut",
            "puttock",
            "pumpion",
            "ratsbane",
            "scut",
            "skainsmate",
            "strumpet",
            "varlot",
            "vassal",
            "whey-face",
            "wagtail",
        };

        // Generate a random insult.
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            txtInsult.Text = "Thou " +
                Column0.RandomElement() + " " +
                Column1.RandomElement() + " " +
                Column2.RandomElement();
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
            this.txtInsult = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtInsult
            // 
            this.txtInsult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInsult.Location = new System.Drawing.Point(12, 49);
            this.txtInsult.Name = "txtInsult";
            this.txtInsult.Size = new System.Drawing.Size(310, 20);
            this.txtInsult.TabIndex = 3;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGenerate.Location = new System.Drawing.Point(130, 11);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // howto_shakespeare_insulter_Form1
            // 
            this.AcceptButton = this.btnGenerate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 81);
            this.Controls.Add(this.txtInsult);
            this.Controls.Add(this.btnGenerate);
            this.Name = "howto_shakespeare_insulter_Form1";
            this.Text = "howto_shakespeare_insulter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInsult;
        private System.Windows.Forms.Button btnGenerate;
    }
}

