<template>
      <div class="mt-2 bg-white dark:bg-gray-800 p-5 w-full rounded-md box-border shadow">
        <h2 class="font-bold text-lg text-gray-800 dark:text-gray-200" v-if="title">
          {{ title }}
        </h2>
        <p class="text-gray-400 font-lexend font-normal" v-if="subtitle">
          {{ subtitle }}
        </p>
        <div class="wrapping-table mt-10">
          <table class="w-full text-sm text-left text-gray-500 dark:text-gray-400 lg:overflow-auto overflow-x-scroll">
            <thead class="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
              <tr>
                <th scope="col" class="uppercase px-6 py-3" v-for="header in headers" :key="header.key">{{ header.label }}</th>
              </tr>
            </thead>
            <tbody>
              <tr class="bg-white border-b dark:bg-gray-800 dark:border-gray-700 odd:bg-white even:bg-gray-50"
                v-for="item in items" :key="`item-${item}`"
              >
                <td class="px-6 py-4" v-for="header in headers" :key="`header-item-${header.key}`">
                  <slot :name="`cell(${header.key})`" :data="item[header.key]">
                    {{ item[header.key] }}
                  </slot>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
        <div class="wrapper-button mt-3">
            <slot name="footer"></slot>
        </div>
    </div>
</template>

<script>
export default {
    name: 'DataTable',
    props: {
        headers: {
            type: Array,
            default: () => ([])
        },
        title: String,
        subtitle: String,
        items: {
            type: Array,
            default: () => ([]),
        }
    }
}
</script>

<style>

</style>