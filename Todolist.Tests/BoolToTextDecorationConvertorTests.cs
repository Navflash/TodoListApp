using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TodoList.Helpers;
using Xamarin.Forms;

namespace Todolist.Tests
{
    public class BoolToTextDecorationConvertorTests
    {
        [Fact]
        public void Convert_returns_strikethrough_when_item_is_complelted()
        {
            //Arrange
            var convertor = new BoolToTextDecoration();
            //Act
            var result = convertor.Convert(true, null, null, null);
            //Assert
            Assert.Equal(TextDecorations.Strikethrough, (TextDecorations)result);
        }

        [Fact]
        public void Convert_returns_none_when_item_is_not_complelted()
        {
            //Arrange
            var convertor = new BoolToTextDecoration();
            //Act
            var result = convertor.Convert(false, null, null, null);
            //Assert
            Assert.Equal(TextDecorations.None, (TextDecorations)result);
        }
    }
}
