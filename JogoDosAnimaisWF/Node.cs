using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace JogoDosAnimaisWF
{
    [Serializable]
    class Node
    {
        public string question;
        public string animal;
        public Node noNode;
        public Node yesNode;

        public Node(string animalValue)
        {
            animal = animalValue;
            noNode = null;
            yesNode = null;
        }

        public void setNoNode(Node node)
        {
            noNode = node;
        }

        public void setYesNode(Node node)
        {
            yesNode = node;
        }

        public void query()
        {
            if (this.isQuestion())
            {
                string result = callMessageBox(this.animal);

                if (result.Equals("Yes"))
                {
                    yesNode.query();
                }
                else
                {
                    noNode.query();
                }
            }
            else
            {
                this.onQueryObject();
            }
        }

        private bool isQuestion()
        {
            return !(noNode == null && yesNode == null);
        }

        private void onQueryObject()
        {
            string result = callMessageBox(this.animal);

            if (result.Equals("Yes"))
                MessageBox.Show("Acertei de novo!");
            else
                updateTree();
        }

        private string callMessageBox(string animal)
        {
            string msg;

            if (this.isQuestion())
            {
                msg = this.question;
            }
            else
            {
                msg = string.Format("O animal que você pensou é {0}?", this.animal);
            }

            return (MessageBox.Show(msg,
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question)).ToString();
        }

        private void updateTree()
        {
            string newAnimal = CustomPrompt.ShowDialog("Qual o animal que você pensou?", "Desisto");
            string newQuestion = CustomPrompt.ShowDialog(string.Format("Um(a) {0} _____ mas um {1} não.", newAnimal, this.animal), 
                                                         "Complete");

            this.noNode = new Node(this.animal);
            this.yesNode = new Node(newAnimal);
            this.question = string.Format("O animal que você pensou {0}?", newQuestion);
        }
    }
}
