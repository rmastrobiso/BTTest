using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDosAnimaisWF
{
    class BinaryTree
    {
        public Node rootNode;

        public BinaryTree(string question, string yesGuess, string noGuess)
        {
            rootNode = new Node("");
            rootNode.setYesNode(new Node(yesGuess));
            rootNode.setNoNode(new Node(noGuess));
            rootNode.question = question;
        }

        public void query()
        {
            rootNode.query();
        }
    }
}
