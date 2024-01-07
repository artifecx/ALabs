﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ALabs.LessonNFA {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ContentResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ContentResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ALabs.LessonNFA.ContentResources", typeof(ContentResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] C1E1 {
            get {
                object obj = ResourceManager.GetObject("C1E1", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] C1E2 {
            get {
                object obj = ResourceManager.GetObject("C1E2", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Nondeterministic Finite Automaton (NFA) is a type of finite state machine, which is a mathematical model used to describe computation processes. NFAs are similar to Deterministic Finite Automata (DFA) but with a key difference in their transition behavior..
        /// </summary>
        internal static string C1P1 {
            get {
                return ResourceManager.GetString("C1P1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to In a DFA, for each state and input symbol, there is exactly one transition to the next state. On the other hand, NFAs allow multiple transitions from a given state for the same input symbol. This non-deterministic feature means that an NFA can be in multiple states simultaneously, leading to multiple possible paths for processing an input string..
        /// </summary>
        internal static string C1P2 {
            get {
                return ResourceManager.GetString("C1P2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to NFAs are often used in theoretical computer science and formal language theory to describe and recognize regular languages. They provide a more expressive way to represent certain language patterns and simplify the design of some automata for specific applications. However, it&apos;s important to note that NFAs and DFAs recognize the same class of languages known as regular languages..
        /// </summary>
        internal static string C1P3 {
            get {
                return ResourceManager.GetString("C1P3", resourceCulture);
            }
        }
    }
}