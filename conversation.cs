using System;
using System.Collections.Generic;


namespace file_io {
    class conversation {
        private List<question> Qs;

        // conversation(filename) loads the file at the relative location filename
        // effects: allocates memory
        // efficiency: O(n^2)
        public conversation(string filename) {
            this.Qs = new List<question>();

            // Store each line of the file in contents
            string [] contents = System.IO.File.ReadAllLines(@filename);

            int i = -1; // index variable

            // Parse through the dialogue file and make dialogue nodes
            foreach (string line in contents) {
                if (line.Contains("DIALOGUE")) {
                    question q = new question();
                    Qs.Add(q);
                    i++;
                }
                else if (line.Contains("SPEAKER")) Qs[i].set_speaker(line.Substring(9, line.Length - 9));
                else if (line.Contains("TEXT")) Qs[i].set_text(line.Substring(6, line.Length - 6));
                else if (line.Contains("OPTION")) {
                    if (!line.Contains("NULL")) Qs[i].addOption(line.Substring(10, line.Length - 10));
                }
                else if (line.Contains("RESPONSE")) {
                    int l = line[12];
                    Qs[i].addResponse(line[12] - '0');
                }
            }
        }

        // run() runs through a conversation with the user
        // efficiency: O(h) where h is the height of the dialogue tree
        public void run() {
            int i = 0;
            while (true) {
                i = this.Qs[i].ask();
                if (i == 0) break;
            }
        }
    }
}