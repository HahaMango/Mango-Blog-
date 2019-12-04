<template>
    <div>
        <span><ion-icon name="heart"></ion-icon>{{like}}</span>
        <span><ion-icon name="book"></ion-icon>{{read}}</span>
        <span><ion-icon name="chatboxes"></ion-icon>{{command}}</span>
    </div>
</template>

<script>
export default {
    props:["read","like","command"]
}
</script>