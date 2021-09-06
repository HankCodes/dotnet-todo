
const todoList = document.querySelector('.todo-list')
todoList && todoList.addEventListener('click', (e) => {
    if (!e.target.id.includes('trash-')) return

    const itemId = e.target.id.replace('trash-', '')
    const itemTitle = document.querySelector('#item-' + itemId).getAttribute('data-title')

    const template = document.querySelector("#template-popup-delete")
    const popup = template.content.cloneNode(true).querySelector('.popup')
    const window = popup.querySelector('.popup__window')
    const titleEl = popup.querySelector('#delete-item')
    const input = popup.querySelector('#delete-item-input')

    titleEl.textContent = itemTitle
    input.value = itemId

    const closeBtn = popup.querySelector('#popup-close')
    closeBtn.addEventListener('click', e => {
        window.classList.remove('fade-in-up')
        window.classList.add('fade-out-up')
        popup.classList.remove('fade-in')
        popup.classList.add('fade-out')

        setTimeout(() => popup.remove(), 1000)
    })

    document.body.appendChild(popup) 
})