﻿using System.Diagnostics;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace GlobalMethodsAndVars
{
    public static class GlobalVars
    {
        public static string MainHtmlImageAtTop { get; set; } = "Create a Isaac Asimov Caves of Steel geometry mathematical oriented SF image";
        public static string TitleOfBook { get; set; } = "Asimov In Space";
        public static string FirstPageInitiation { get; set; } =
            $@"<p style=""font-family: 'Garamond', serif; font-size: 25px; font-style: italic; color: black; margin: 0;"">
                Inspired by the Caves of Steel Universe. 
                <br />In the style of<br /><br />
                <br />Isaac Asimov.<br /><br /><br />
                Images based on Isaac Asimov.
            </p>";
    }
    public static class DocHtmlVars
    {
        public static string foreTitlePrefix { get; set; } = "Write an extensive and detailed book chapter in the style of Isaac Asimovs The Caves of Steel and The Robots of Dawn. The chapter must be large and immersive, featuring richly developed characters with nuanced psychological depth. Include intelligent, thought-provoking dialogue that explores complex social, ethical, or technological themes. The interactions between characters should be subtle, sharp, and layered with tension or unspoken motives, leading to unforeseen twists and turns in the narrative. Incorporate vivid and atmospheric descriptions of futuristic urban or planetary settings—sprawling Cities, Spacer environments, or high-tech interiors—grounded in Asimovs clean, minimalistic prose. Ensure that the tone reflects the sociological, investigative, and philosophical essence of Asimovs Robot Series. Write this chapter on the title – ";
        public static string firstImagePrefix { get; set; } = "Create a Isaac Asimov Caves of Steel geometry mathematical oriented SF image";
        public static string forPrompt { get; set; } = "Begin the chapter with an immersive return to Earth in the age of *The Caves of Steel*. " +
                                "Paint the world in rich, atmospheric detail—not by describing everything, but by revealing what matters: " +
                                "the steel ceilings that feel too low, the dim corridors that enforce routine, the subtle anxiety of a society " +
                                "squeezed between fear of Spacers and fear of change. Let the chapter be long and deliberate—designed not just to entertain, " +
                                "but to provoke thought. Let the reader *experience* the city, from the antiseptic scent of food dispensers to the hum of mechanical walls. " +
                                "Introduce characters through their subtle contradictions—the man who hates robots but can't explain why, " +
                                "the woman who trusts logic but longs for something irrational. Allow fear, bias, and ambition to ripple beneath polite conversation. " +
                                "Dialogue should be intelligent and layered, with motives revealed in hints and reversals. Let wit emerge as irony—an acknowledgment of a world " +
                                "built on compromise. " +
                                "The human-robot dynamic must be felt from the start, not as a battle, but as an uneasy truce woven into every public space and private fear. " +
                                ". Let the plot guide structure, but allow the theme and message to emerge slowly—through mood, voice, and logic. " +
                                "The chapter should feel like a conversation between the reader and the world. Let meaning surface on its own, " +
                                "so that when the title finally arrives, it does not explain, but affirms what the reader has already come to understand." +
                                "Base the chapter around this plot: ";
        public static string runningPrompt { get; set; } =
                                "Let the tone and momentum carry forward with natural continuity, but deepen the story with evolving emotional resonance, " +
                                "philosophical inquiry, and narrative complexity. Allow for a rich progression—not in sudden shifts, but in gradually unfolding " +
                                "dialogue, inner thought, and subtle re-alignments in character dynamics. Let tension build slowly, like pressure within a sealed chamber. " +
                                "Make the chapter lengthy and immersive—encourage expansive scenes that explore both external detail and internal dissonance. " +
                                "Let conversations stretch, not with filler, but with purpose—characters should think, reason, hesitate, contradict themselves, " +
                                "and reveal more in silence than in speech. Wit should emerge dry and sharply embedded in the realities of urban life and social order. " +
                                "Twists should be the result of psychological friction, not plot mechanics. Base them in personal ethics, political ambiguity, and identity conflicts. " +
                                "Embed the action within the claustrophobic infrastructure of the Cities: the sterile corridors, communal kitchens, overcrowded elevators, " +
                                "and the omnipresent sound of machinery that regulates life with brutal indifference. " +
                                "Use language that reflects Asimov’s—precise, unadorned, but filled with quiet wisdom. Let the narrative grow toward its insight, " +
                                "not through announcements, but through accumulated nuance. Allow the reader to discover meaning alongside the characters, " +
                                "and let the title of the chapter feel like the final note in a well-reasoned argument rather than a headline." +
                                "Continue the story seamlessly from the previous chapter: ";
        public static string extraTouch { get; set; } = "Ensure the chapter balances narrative momentum with deep philosophical undercurrents, evoking questions of humanity, logic, and moral ambiguity.";
    }
}
