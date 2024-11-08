using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls; // Добавьте эту директиву
using System.Windows;

namespace TextProcessorApp
{
    using System.Collections.Generic;
    using System.Windows.Controls;

    public class TextEditor
    {
        private Stack<TextAction> _actionStack = new Stack<TextAction>();
        private Stack<TextAction> _undoStack = new Stack<TextAction>();
        private TextBox _textBox;

        public TextEditor(TextBox textBox)
        {
            _textBox = textBox;
            _textBox.TextChanged += TextBox_TextChanged;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var changes = e.Changes;
            foreach (var change in changes)
            {
                if (change.AddedLength > 0)
                {
                    var addedText = _textBox.Text.Substring(change.Offset, change.AddedLength);
                    var action = new TextAction("Add", addedText, change.Offset);
                    _actionStack.Push(action);
                    _undoStack.Clear(); // Очищаем стек отмененных действий при новом действии
                }
                else if (change.RemovedLength > 0)
                {
                    var removedText = _textBox.Text.Substring(change.Offset, change.RemovedLength);
                    var action = new TextAction("Remove", removedText, change.Offset);
                    _actionStack.Push(action);
                    _undoStack.Clear(); // Очищаем стек отмененных действий при новом действии
                }
            }
        }

        public void Undo()
        {
            if (_actionStack.Count > 0)
            {
                var action = _actionStack.Pop();
                _undoStack.Push(action);

                if (action.ActionType == "Add")
                {
                    _textBox.Text = _textBox.Text.Remove(action.Position, action.Text.Length);
                }
                else if (action.ActionType == "Remove")
                {
                    _textBox.Text = _textBox.Text.Insert(action.Position, action.Text);
                }

                _textBox.CaretIndex = action.Position;
            }
        }

        public void Redo()
        {
            if (_undoStack.Count > 0)
            {
                var action = _undoStack.Pop();
                _actionStack.Push(action);

                if (action.ActionType == "Add")
                {
                    _textBox.Text = _textBox.Text.Insert(action.Position, action.Text);
                }
                else if (action.ActionType == "Remove")
                {
                    _textBox.Text = _textBox.Text.Remove(action.Position, action.Text.Length);
                }

                _textBox.CaretIndex = action.Position + action.Text.Length;
            }
        }
    }


}
