<template>
    <div>
        <h2 class="dark:text-gray-200 text-xl font-bold">Partner Store</h2>
        <p class="text-gray-400">This is list if your partner online.</p>
        <p class="font-medium font-lg mt-5 dark:text-gray-200">Online</p>
        <div class="mt-4 grid grid-cols-1 gap-4">
            <button class="w-full box-border flex gap-4" v-for="user in onlineUsers" :key="user.name">
                <span>
                    <img
                    :src="getImage(user.image)"
                    alt=""
                    width="50"
                    height="50"
                    class="rounded-full"
                    />
                </span>
                <span class="text-left">
                    <h1 class="font-bold text-xl dark:text-gray-200">{{ user.name }}</h1>
                    <p class="text-gray-400 dark:text-gray-200">online</p>
                </span>
            </button>
        </div>
        <div class="mt-4 grid grid-cols-1 gap-4">
            <p class="font-medium font-lg mt-5 dark:text-gray-200">Offline</p>
            <button class="w-full box-border flex gap-4" v-for="user in offlineUsers" :key="user.name">
                <span>
                    <img
                    :src="getImage(user.image)"
                    alt=""
                    width="50"
                    height="50"
                    class="rounded-full"
                    />
                </span>
                <span class="text-left">
                    <h1 class="font-bold text-xl dark:text-gray-200">{{ user.name }}</h1>
                    <p class="text-gray-400 dark:text-gray-200">offline</p>
                </span>
            </button>
        </div>
      </div>
</template>

<script>
export default {
    name: 'Partners',
    data() {
        return {
            users: [
                {
                    name: 'Elizabeth Begum',
                    isOnline: true,
                    timeAgo: '4 Hours ago',
                    image: 'user1.png'
                },
                {
                    name: 'Taylor Neal',
                    isOnline: true,
                    timeAgo: '4 Hours ago',
                    image: 'user2.png'
                },
                {
                    name: 'Ethan Roger',
                    isOnline: false,
                    timeAgo: '',
                    image: 'user3.png'
                },
                {
                    name: 'Bruno Barron',
                    isOnline: false,
                    timeAgo: '',
                    image: 'user4.png'
                },
                {
                    name: 'Tobi Ferreira',
                    isOnline: true,
                    timeAgo: '',
                    image: 'user5.png'
                },
            ]
        }
    },
    computed: {
        onlineUsers() {
            return this.users.filter(user => user.isOnline)
        },
        offlineUsers() {
            return this.users.filter(user => !user.isOnline)
        }
    },
    methods: {
        getImage(name) {
            return require(`../assets/img/${name}`)
        }
    }
}
</script>
