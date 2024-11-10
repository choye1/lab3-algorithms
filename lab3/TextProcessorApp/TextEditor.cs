using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.IO;

namespace TextProcessorApp
{
    public class TextEditor
    {
        private Stack<TextAction> _undoStack = new Stack<TextAction>();
        private Stack<TextAction> _redoStack = new Stack<TextAction>();
        private TextBox _textBox;
        private bool _isHandlingUndoRedo; // флаг для блокировки TextChanged при Undo/Redo
        private string _text;

        public TextEditor(TextBox textBox)
        {
            _textBox = textBox;
            _textBox.TextChanged += TextBox_TextChanged;
            _textBox.PreviewKeyDown += TextBox_PreviewKeyDown;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Игнорируем изменения текста, вызванные операцией Undo/Redo
            if (_isHandlingUndoRedo) return;

            foreach (var change in e.Changes)
            {
                if (change.AddedLength > 0)
                {
                    _text = _textBox.Text;
                    string addedText = _textBox.Text.Substring(change.Offset, change.AddedLength);
                    var action = new TextAction("Add", addedText, change.Offset);
                    _undoStack.Push(action);
                    _redoStack.Clear(); // очищаем стек Redo при любом новом изменении
                }
                else if (change.RemovedLength > 0 && change.Offset + change.RemovedLength <= _textBox.Text.Length + change.RemovedLength)
                {
                    // Удаление текста
                    string removedText = _text.Substring(change.Offset, change.RemovedLength);
                    var action = new TextAction("Remove", removedText, change.Offset);
                    _undoStack.Push(action);
                    _redoStack.Clear();
                }
            }
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Если нажата клавиша Backspace, регистрируем удаление символа
            if (e.Key == Key.Back && _textBox.CaretIndex > 0)
            {
                int pos = _textBox.CaretIndex - 1;
                string removedText = _textBox.Text.Substring(pos, 1);
                var action = new TextAction("Remove", removedText, pos);
                _undoStack.Push(action);
                _redoStack.Clear();
            }
        }

        public void Undo()
        {
            if (_undoStack.Count > 0)
            {
                var action = _undoStack.Pop();
                _redoStack.Push(action);

                _isHandlingUndoRedo = true; // Блокируем обработку TextChanged

                if (action.ActionType == "Add")
                {
                    _textBox.Text = _textBox.Text.Remove(action.Position, action.Text.Length);
                }
                else if (action.ActionType == "Remove")
                {
                    _textBox.Text = _textBox.Text.Insert(action.Position, action.Text);
                }

                _textBox.CaretIndex = action.Position;
                _isHandlingUndoRedo = false; // Разблокируем TextChanged
            }
        }

        public void Redo()
        {
            if (_redoStack.Count > 0)
            {
                var action = _redoStack.Pop();
                _undoStack.Push(action);

                _isHandlingUndoRedo = true;

                if (action.ActionType == "Add")
                {
                    _textBox.Text = _textBox.Text.Insert(action.Position, action.Text);
                }
                else if (action.ActionType == "Remove")
                {
                    _textBox.Text = _textBox.Text.Remove(action.Position, action.Text.Length);
                }

                _textBox.CaretIndex = action.Position + action.Text.Length;
                _isHandlingUndoRedo = false;
            }
        }

        public void SaveToFile(string path)
        {
            File.WriteAllText(path, _textBox.Text);
            MessageBox.Show($"Файл успешно сохранен: {path}", "Сохранение файла", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

