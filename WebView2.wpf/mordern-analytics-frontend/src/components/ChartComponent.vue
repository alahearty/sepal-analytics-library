<template>
    <div>
        <h2 class="font-bold text-lg text-gray-800 dark:text-gray-200">
          {{ title }}
        </h2>
        <p class="text-gray-400 font-lexend font-normal">
          {{ subtitle }}
        </p>
        <span class="float-right">
          <h2 class="text-green-500 -mt-12 flex">
            <span class="mr-2"> {{ title }} </span>
            <span>
              <Icon icon="akar-icons:arrow-up" />
            </span>
          </h2>
        </span>
        <div class="wrapper-chart mt-5">
          <slot></slot>
          <br />
          <hr />
          <div class="wrapper-button mt-3">
            <select name="" id="" class="dark:bg-gray-800 dark:hover:bg-gray-700 border-gray-200 dark:border-gray-300 border max-w-lg px-4 py-3 block rounded-md text-gray-500 dark:text-gray-400">
              <option value="">Last 7 days</option>
            </select>
            <button class="uppercase float-right -mt-7 border-b border-red-600 text-red-600">
              {{report}}
            </button>
          </div>
        </div>
    </div>
</template>

<script>
export default {
    name: 'ChartComponent',
    props: {
        title: {
            type: String,
            required: true
        },
        subtitle: {
            type: String,
            required: true
        },
        report: {
            type: String,
            required: true
        },
        total: String,
        
    }
}
</script>

<style>

</style>