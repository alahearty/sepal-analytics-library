<template>
 <div class="card bg-white dark:bg-gray-800 w-full rounded-md p-5 shadow flex">
  <div class="card bg-white dark:bg-gray-800 w-full rounded-md p-5 shadow flex">
        <div class="p-2 max-w-sm">
             <slot></slot>
        </div>

        <div class="block p-2 w-full">
          <p class="font-semibold text-gray-900 dark:text-gray-200 text-xl">
           {{ total }}
          </p>
          <h2 class="font-normal text-gray-400 text-md mt-1">{{totalPayout}}</h2>
        </div>
      </div>
    </div>
</template>

<script>
export default {
    name: 'Card',
    props: {
        total: {
            type: String,
            required: true
        },
        totalPayout: {
            type: String,
            required: true
        },
    }
}
</script>

