$('.k-pager-sizes')
    .contents()
    .filter(function () {
        return this.nodeType === 3;
    }).remove();