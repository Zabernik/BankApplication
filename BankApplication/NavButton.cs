﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankApplication
{
    /// <summary>
    /// Wykonaj kroki 1a lub 1b, a następnie 2, aby użyć tej kontrolki niestandardowej w pliku XAML.
    ///
    /// Krok 1a) Użycie tej kontrolki niestandardowej w pliku XAML, który istnieje w bieżącym projekcie.
    /// Dodaj ten atrybut XmlNamespace do głównego elementu pliku znaczników, gdzie jest 
    /// do użycia:
    ///
    ///     xmlns:MyNamespace="clr-namespace:BankApplication"
    ///
    ///
    /// Krok 1b) Użycie tej kontrolki niestandardowej w pliku XAML, który istnieje w innym projekcie.
    /// Dodaj ten atrybut XmlNamespace do głównego elementu pliku znaczników, gdzie jest 
    /// do użycia:
    ///
    ///     xmlns:MyNamespace="clr-namespace:BankApplication;assembly=BankApplication"
    ///
    /// Należy również dodać odwołanie do projektu z projektu, w którym znajduje się plik XAML
    /// do tego projektu i skompiluj ponownie, aby uniknąć błędów kompilacji:
    ///
    ///     Kliknij prawym przyciskiem myszy docelowy projekt w Eksploratorze rozwiązań i
    ///     „Dodaj odwołanie”->„Projekty”->[Wyszukaj i wybierz ten projekt]
    ///
    ///
    /// Krok 2)
    /// Przejdź dalej i użyj swojego formantu w pliku XAML.
    ///
    ///     <MyNamespace:NavButton/>
    ///
    /// </summary>
    public class NavButton : ListBoxItem
    {
        static NavButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavButton), new FrameworkPropertyMetadata(typeof(NavButton)));
        }




        public Uri NavLink
        {
            get { return (Uri)GetValue(NavLinkProperty); }
            set { SetValue(NavLinkProperty, value); }
        }
        public static readonly DependencyProperty NavLinkProperty = DependencyProperty.Register("MyProperty", typeof(Uri), typeof(NavButton), new PropertyMetadata(null));



        public Geometry Icon
        {
            get { return (Geometry)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(Geometry), typeof(NavButton), new PropertyMetadata(null));


    }
}