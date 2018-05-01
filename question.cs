using System;
using System.Collections.Generic;


namespace file_io {
    class question {
        private string question_text; // content of the question
        private string speaker; // whoever poses the question
        private List<string> options; // options available
        private List<int> responses; // responses to all options

        // question() allocates memory for a new question
        // effects: allocates memory
        // efficiency: O(1)
        public question() {
            this.options = new List<string>();
            this.responses = new List<int>();
        }

        // set_text(new_text) changes question_text to new_text
        // effects: mutates data
        // efficiency: O(1)
        public void set_text(string new_text) {
            this.question_text = new_text;
        }

        // set_speaker(spk) changes speaker to spk
        // effects: mutates data
        // efficiency: O(1)
        public void set_speaker(string spk) {
            this.speaker = spk;
        }

        // addOption(new_op) adds new_op to options
        // effects: mutates data
        // efficiency: O(1)
        public void addOption(string new_op) {
            this.options.Add(new_op);
        }

        // addResponse(new_re) adds new_re to responses
        // effects: mutates data
        // efficiency: O(1)
        public void addResponse(int new_re) {
            this.responses.Add(new_re);
        }

        // get_speaker() returns speaker
        // efficiency: O(1)
        public string get_speaker() { return speaker; }

        // get_text returns question_text
        // efficiency: O(1)
        public string get_text() { return question_text; }

        // ask() displays question_text, accepts input from the user, and returns the
        //      address of the next dialogue node in the conversation
        // effects: input/output
        // efficiency: O(1)
        public int ask() {
            Console.WriteLine();
            Console.WriteLine(this.speaker + ":");
            Console.WriteLine(this.question_text);
            if (this.options.Count == 0 && this.responses.Count == 1) return this.responses[0];
            else if (this.options.Count == 0) return 0;
            for (int i = 0; i < this.options.Count; i++) Console.WriteLine((i+1) + ". " + this.options[i]);
            string c = Console.ReadLine();
            int j = c[0];
            j -= '0';
            if (j <= this.responses.Count && j > 0) return this.responses[j-1];
            else return 0;
        }
    }
}
