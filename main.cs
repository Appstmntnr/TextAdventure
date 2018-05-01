using System;

namespace file_io {
    class Hello {
        static void Main() {
            conversation convo = new conversation("conversation.txt");
            convo.run();
        }
    }
}
