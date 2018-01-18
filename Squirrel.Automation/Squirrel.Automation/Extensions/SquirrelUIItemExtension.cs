using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White.Factory;
using TestStack.White.UIItems;

namespace Squirrel.Automation.Extensions
{
    public static class SquirrelUIItemExtension
    {
        public static T GetParentElement<T>(this IUIItem thisItem) where T : IUIItem
        {
            var parent = TreeWalker.ControlViewWalker.GetParent(thisItem.AutomationElement);
            var uiItem = new DictionaryMappedItemFactory().Create(parent, thisItem.ActionListener);
            return (T)UIItemProxyFactory.Create(uiItem, uiItem.ActionListener);
        }

        public static T GetPreviousSibling<T>(this IUIItem thisItem) where T : IUIItem
        {
            var parent = TreeWalker.ControlViewWalker.GetPreviousSibling(thisItem.AutomationElement);
            var uiItem = new DictionaryMappedItemFactory().Create(parent, thisItem.ActionListener);
            return (T)UIItemProxyFactory.Create(uiItem, uiItem.ActionListener);
        }

        public static T GetParentElement<T>(this AutomationElement automation, IUIItem uiitem) where T : IUIItem
        {
            var parent = TreeWalker.ControlViewWalker.GetParent(automation);
            var uiItem = new DictionaryMappedItemFactory().Create(parent, uiitem.ActionListener);
            return (T)UIItemProxyFactory.Create(uiItem, uiItem.ActionListener);
        }

        public static T GetChildElement<T>(this IUIItem thisItem) where T : IUIItem
        {
            var child = TreeWalker.ControlViewWalker.GetFirstChild(thisItem.AutomationElement);
            var uiItem = new DictionaryMappedItemFactory().Create(child, thisItem.ActionListener);
            return (T)UIItemProxyFactory.Create(uiItem, uiItem.ActionListener);
        }

    }
}
