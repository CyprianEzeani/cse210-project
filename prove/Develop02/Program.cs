                          // Program Diagram 

/*
                            +-----------------+
                            |     Program     |
                            +-----------------+
                            | -journal        |
                            +-----------------+
                                    |
                                    |
                                    |
                        +-----------+-----------+
                        |                       |
                 +------+--------+      +-------+-----+
                 |  PromptList   |      |     Entry   |
                 +---------------+      +-------------+
                 | -prompts      |      | -prompt     |
                 |               |      | -response   |
                 | +get_prompt() |      | -date       |
                 +---------------+      +-------------+
                                    |
                                    |
                      +-------------+-------------+
                      |             |             |
            +---------+-----+ +-----+---------+ +------------+
            |   SaveToFile  | |  LoadFromFile | |  Display   |
            +---------------+ +---------------+ +------------+
            | -filename     | | -filename     | | -journal   |
            |               | |               | |            |
            | +save()       | | +load()       | | +display() |
            +---------------+ +---------------+ +------------+     */